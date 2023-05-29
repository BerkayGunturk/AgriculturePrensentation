using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {

            services.AddScoped<IServiceService, ServiceManager>();//
            services.AddScoped<IServiceDal, EfServiceDal>(); //    EKLENDİ !
            services.AddScoped<ITeamService, TeamManager>();//
            services.AddScoped<ITeamDal, EfTeamDal>(); //    EKLENDİ !
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnoucementDal>();
            services.AddScoped<IImageService, ImageManager>();
            services.AddScoped<IImageDal, EfImageDal>();
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IAddressDal, EfAddressDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<ISocialMedialService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<IAdminService, AdminManager>();
            services.AddScoped<IAdminDal, EfAdminDal>();
        }
    }
}
