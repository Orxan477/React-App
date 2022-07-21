using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Education.Business.Profiles
{
    public static class MapperServiceExtension
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper());
            }).CreateMapper());
        }
    }
}
