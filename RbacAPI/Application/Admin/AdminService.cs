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
            throw new NotImplementedException();
        }

        public ResultDto Register(AdminDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
