using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Online_courses_CourseP_.Domain;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.Repositories.EntityFramework;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Service;
using System;
using AutoMapper;
using Online_courses_CourseP_.Areas.Admin;
using Online_courses_CourseP_.Areas.Tutor;

namespace Online_courses_CourseP_
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public async void ConfigureServices(IServiceCollection services)
        {
            //подключаем конфиг из appsetting.json
            Configuration.Bind("Project", new Config());

            //подключаем нужный функционал приложения в качестве сервисов
            services.AddScoped<IAdminRepository, EFAdminRepository>();
            services.AddScoped<ICourseRepository, EFCourseRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IGroupRepository, EFGroupRepository>();
            services.AddScoped<ILessonRepository, EFLessonRepository>();
            services.AddScoped<ILessonTypeRepository, EFLessonTypeRepository>();
            services.AddScoped<IResponsibilityAgreementRepository, EFResponsibilityAgreementRepository>();
            services.AddScoped<ISkillLevelRepository, EFSkillLevelRepository>();
            services.AddScoped<IStudentRepository, EFStudentRepository>();
            services.AddScoped<ITeacherRepository, EFTeacherRepository>();
            services.AddScoped<ITutorRepository, EFTutorRepository>();
            services.AddScoped<IAffiliationAgreementRepository, EFAffiliationAgreementRepository>();
            services.AddScoped<DataManager>();
            services.AddScoped<_DataManager>();

            //подключаем контекст БД
            services.AddDbContext<SchoolDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            
            //настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<SchoolDbContext>().AddDefaultTokenProviders();

            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "Online-CoursesAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //настраиваем политику авторизации для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("OwnerArea", policy => { policy.RequireRole("owner"); });
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
                x.AddPolicy("TutorArea", policy => { policy.RequireRole("tutor"); });
                x.AddPolicy("TeacherArea", policy => { policy.RequireRole("teacher"); });
                x.AddPolicy("StudentArea", policy => { policy.RequireRole("student"); });
            });

            //добавляем сервисы для контроллеров и представлений (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new UserAreaAuthorization("Owner", "OwnerArea"));
                x.Conventions.Add(new UserAreaAuthorization("Admin", "AdminArea"));
                x.Conventions.Add(new UserAreaAuthorization("Tutor", "TutorArea"));
                x.Conventions.Add(new UserAreaAuthorization("Teacher", "TeacherArea"));
                x.Conventions.Add(new UserAreaAuthorization("Student", "StudentArea"));
            }).AddSessionStateTempDataProvider();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Вы можете установить время бездействия сессии
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAutoMapper(typeof(Startup));
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //!!! порядок регистрации middleware очень важен

            //в процессе разработки нам важно видеть какие именно ошибки
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //подключаем поддержку статичных файлов в приложении (css, js и т.д.)
            app.UseStaticFiles();

            //подключаем систему маршрутизации
            app.UseRouting();

            //подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            //регистриуруем нужные нам маршруты (ендпоинты)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("owner", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("tutor", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("teacher", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("student", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            using(var scope = app.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "admin", "tutor", "teacher", "student" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
