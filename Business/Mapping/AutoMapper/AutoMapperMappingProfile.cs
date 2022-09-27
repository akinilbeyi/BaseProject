using AutoMapper;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.Extensions.DependencyInjection;
using Shared.Utilities.Security;
using Shared.Utilities.Service;

namespace Business.Mapping.AutoMapper;
public class AutoMapperMappingProfile : Profile
{
    public AutoMapperMappingProfile()
    {
        var hashingHelper = IoCHelper.ServiceProvider?.GetService<DataHashingHelper>();

        CreateMap<UserDto, User>()
            .ForMember(x => x.PasswordHash, source => source.MapFrom(s => hashingHelper!.Protect(s.Password!)));

        CreateMap<User, UserDto>()
            .ForMember(x => x.Password, source => source.MapFrom(s => hashingHelper!.UnProtect(s.PasswordHash!)));

    }
}
