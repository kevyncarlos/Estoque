using App.Models;
using App.Services;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Método ConfigureServices para adicionar serviços ao container da aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            #region Contexto do banco de dados
            //Adição do serviço de banco de dados
            services.AddDbContextPool<AppDBContext>(options =>
                options.UseInMemoryDatabase(Configuration.GetConnectionString("Conn")));
            #endregion

            #region Configução de autenticação por cookie criptografado
            //Adição e configuração do serviço de autenticação por cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.AccessDeniedPath = "/Account/Denied";
                });
            #endregion

            #region Injeções de Dependência
            //Injeções de dependências para uso na aplicação
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, User>();
            #endregion

            //Adiciona a estrutura MVC na aplicação
            services.AddMvc();
        }

        // Método Configure para configurar o pipeline da requisição HTTP
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region Tratamento de exceções
            //Exceção para o ambiente de desenvolvimento
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            //Exceção para o ambiente de produção
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?statuscode={0}");
            }
            #endregion

            //Faz com que a aplicação "enxergue" a pasta pública wwwroot
            app.UseStaticFiles();

            #region Configuração de rotas
            //Define a estrutura das rotas do MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion
            
        }
    }
}
