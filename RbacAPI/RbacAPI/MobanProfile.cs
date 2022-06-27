using AutoMapper;

namespace RbacAPI
{
    public class MobanProfile:Profile
    {
        public MobanProfile()
        {
            CreateMap<Moban, MonbanDto>();
        }
    }
}
