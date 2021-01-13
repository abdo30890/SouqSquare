using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Final.Project.Startup))]

namespace Final.Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
    //public void ConfigureServices(IServiceCollection services)
    //{
    //    // .... Ignore code before this

    //    // Auto Mapper Configurations
    //    var mapperConfig = new MapperConfiguration(mc =>
    //    {
    //        mc.AddProfile(new MappingProfile());
    //    });

    //    IMapper mapper = mapperConfig.CreateMapper();
    //    services.AddSingleton(mapper);

    //    services.AddMvc();

    //}
}
