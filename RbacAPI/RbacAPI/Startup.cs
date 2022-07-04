using ClassLibraryEF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Repository.MenuRole;

namespace RbacAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddControllers()
            .AddNewtonsoftJson(options => {
                // ����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // ��ʹ���շ�
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                // ����ʱ���ʽ
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                // ���ֶ�Ϊnullֵ�����ֶβ��᷵�ص�ǰ��
                // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddAutoMapper(Assembly.Load("Application"));
            //ע��
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IRolerepository, Rolerepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IMenuRoleRepository, MenuRoleRepository>();

            //services.AddScoped<IMenuRoleRepository>();
           

            services.AddCors(options =>
            {
                options.AddPolicy("cors", policy =>
                {
                    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
            });

            //����������
            services.AddDbContext<MyDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("sqlserver"));
            });
           
           
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
            option =>
            {
                //Token��֤����
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    //�Ƿ���֤������
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtConfig:Issuer"],//������

                    //�Ƿ���֤������
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtConfig:Audience"],//������

                    //�Ƿ���֤��Կ
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:key"])),

                    ValidateLifetime = true, //��֤��������

                    RequireExpirationTime = true, //����ʱ��

                    ClockSkew = TimeSpan.Zero   //ƽ������ƫ��ʱ��
                };
            });
               

                    services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "RbacAPI", Version = "v1" });

                        //����Ȩ��С��
                        c.OperationFilter<AddResponseHeadersFilter>();
                        c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                        c.OperationFilter<SecurityRequirementsOperationFilter>();

                        //��header�����token�����ݵ���̨
                        c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                        {
                            Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
                            Name = "Authorization",//jwtĬ�ϵĲ�������
                            In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                            Type = SecuritySchemeType.ApiKey
                        });
                    });
                }
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RbacAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("cors");
            app.UseAuthentication();
            app.UseAuthorization();
           
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
