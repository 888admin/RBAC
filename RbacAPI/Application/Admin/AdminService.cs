using AutoMapper;
using ClassLibraryEF;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application
{
    public class AdminService : BaseService<Admin, AdminDto>, IAdminService
    {
        private readonly IAdminRepository AdminRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AdminService(IAdminRepository AdminRepository, IMapper mapper, IConfiguration configuration)
            : base(AdminRepository, mapper)
        {
            this.AdminRepository = AdminRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public TokenDto Login(LoginDto dto)
        {
            var list = AdminRepository.GetEntity(m => m.UserName == dto.UserName.Trim());
            if (list == null)
            {
                return new TokenDto { Code = 1, Msg = "用户不存在" };
            }
            if (list.Password.ToLower() != Md5(dto.Password.Trim().ToLower()))
            {
                return new TokenDto { Code = 2, Msg = "密码错误" };
            }
            //生成Token令牌
            IList<Claim> claims = new List<Claim> {
                new Claim(JwtClaimTypes.Id,dto.UserName)
            };
            //JWt密钥
            var skey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:key"]));
            //算法，签证证书
            var cred = new SigningCredentials(skey, SecurityAlgorithms.HmacSha256);
            //过期时间
            DateTime exTime = DateTime.UtcNow.AddHours(10);
            //Payload负载
            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"], //发布者、颁发者
                audience: configuration["JwtConfig:Audience"],  //令牌接收者
                claims: claims,  //自定义声明信息
                notBefore: DateTime.UtcNow,    //创建时间
                expires: exTime,     //过期时间
                signingCredentials: cred
                );

            var handler = new JwtSecurityTokenHandler();

            //生成令牌
            string jwt = handler.WriteToken(token);

            return new TokenDto { Code = 0, Msg = "登录成功", Token = jwt };
        }

        public ResultDto Register(AdminDto dto)
        {
            if (AdminRepository.GetEntity(t => t.UserName == dto.UserName.Trim().ToUpper()) != null)
            {
                return new ResultDto { Code = 1, Msg = "已存在此用户" };
            }
            //密码、注册时间、末次登录时间
            dto.UserName = dto.UserName.Trim().ToUpper();
            dto.Password = Md5(dto.Password.Trim());
            dto.CreateTime = DateTime.Now;
            dto.LastLoginTime = null;
            AdminRepository.AddInfo(mapper.Map<Admin>(dto));
            return new ResultDto { Code = 0, Msg = "注册成功" };
        }

        public Tuple<List<AdminDto>, int> AdminShow(int Pageindex = 1, int PageSize = 2)
        {
            var list =mapper.Map<List<AdminDto>>(AdminRepository.GetQuery().OrderBy(t=>t.AdminId).Skip((Pageindex - 1) * PageSize).Take(PageSize)).ToList();
            var Totalcount = AdminRepository.GetQuery().Count();
            return new Tuple<List<AdminDto>, int>(list, Totalcount);
        }

        private string Md5(string val)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).Select(x => x.ToString("x2")));
        }

        
    }
}
