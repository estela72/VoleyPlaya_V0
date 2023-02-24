using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LigamaniaCoreApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LigamaniaCoreApp.Models;
using LigamaniaCoreApp.Services;
using Microsoft.Extensions.Logging;
using LigamaniaCoreApp.Data.Repository.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AutoMapper;
using System.IO;
using LigamaniaCoreApp.Services.Interfaces;
using Microsoft.Extensions.FileProviders;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using LigamaniaCoreApp.Models.GlobalViewModels;
using System.Linq;
using Serilog;
using LigamaniaCoreApp.Utils;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Helpers;

namespace LigamaniaCoreApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        //readonly ILogger _logger;
        public Startup(ILoggerFactory loggerFactory, IConfiguration configuration, ILogger<Startup> logger)
        {
            //Configuration = configuration;
            //_logger = loggerFactory.CreateLogger<Startup>();
            //_logger = logger;
            // Init Serilog configuration
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //_logger.LogDebug($"Total Services Initially: {services.Count}");

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<SignInManager<ApplicationUser>, ApplicationSignInManager<ApplicationUser>>();

            //Registering ApplicationUserManager. 
            services.TryAddScoped<ApplicationUserManager<ApplicationUser>>();
            services.TryAddScoped<ApplicationSignInManager<ApplicationUser>>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.User.AllowedUserNameCharacters = string.Empty;  // permitir todos los caracteres
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            //Password Strength Setting   
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings   
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings   
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(480);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = false;

                // User settings   
                options.User.RequireUniqueEmail = true;

            });

            //Seting the Account Login page   
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings   
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(480);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login   
                //options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout   
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied   
                options.SlidingExpiration = false;
                options.Cookie.Name = "AuthCookieName";
            });
            //_logger.LogInformation("Added Ligamania configuration to services");

            // Add application repositories
            services.AddTransient<IEquipoRepository, EquipoRepository>();
            services.AddTransient<ITemporadaCompeticionRepository, TemporadaCompeticionRepository>();
            services.AddTransient<INoticiaRepository, NoticiaRepository>();
            services.AddTransient<ITemporadaJugadorRepository, TemporadaJugadorRepository>();
            services.AddTransient<ITemporadaClasificacionRepository, TemporadaClasificacionRepository>();
            services.AddTransient<ICompeticionRepository, CompeticionRepository>();
            services.AddTransient<ITemporadaCompeticionJornadaRepository, TemporadaCompeticionJornadaRepository>();
            services.AddTransient<ICompeticionCategoriaRepository, CompeticionCategoriaRepository>();
            services.AddTransient<ITemporadaCompeticionCategoriaRepository, TemporadaCompeticionCategoriaRepository>();
            services.AddTransient<ITemporadaCompeticionCategoriaReferenciaRepository, TemporadaCompeticionCategoriaReferenciaRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<ITemporadaRepository, TemporadaRepository>();
            services.AddTransient<IHistoricoRepository, HistoricoRepository>();
            services.AddTransient<IPuntuacionHistoricaRepository, PuntuacionHistoricaRepository>();
            services.AddTransient<ICambiosEquipoRepository, CambiosEquipoRepository>();
            services.AddTransient<ITemporadaEquipoRepository, TemporadaEquipoRepository>();
            services.AddTransient<ITemporadaContabilidadRepository, TemporadaContabilidadRepository>();
            services.AddTransient<ITemporadaPremiosRepository, TemporadaPremiosRepository>();
            services.AddTransient<ITemporadaCuadroRepository, TemporadaCuadroRepository>();
            services.AddTransient<ITemporadaPremiosPuestoRepository, TemporadaPremiosPuestoRepository>();
            services.AddTransient<IAlineacionRepository, AlineacionRepository>();
            services.AddTransient<IAlineacionPreviaRepository, AlineacionPreviaRepository>();
            services.AddTransient<IAlineacionCambiosRepository, AlineacionCambioRepository>();
            services.AddTransient<IAlineacionHistoricoRepository, AlineacionHistoricoRepository>();
            services.AddTransient<IControlUsuarioRepository, ControlUsuarioRepository>();
            services.AddTransient<IDocumentsRepository, DocumentsRepository>();
            services.AddTransient<ISettingsRepository, SettingsRepository>();
            services.AddTransient<ICalendarioRepository, CalendarioRepository>();
            services.AddTransient<ICalendarioDetalleRepository, CalendarioDetalleRepository>();
            services.AddTransient<ITemporadaPartidoRepository, TemporadaPartidoRepository>();
            services.AddTransient<IJugadorRepository, JugadorRepository>();
            services.AddTransient<IPuestoRepository, PuestoRepository>();
            services.AddTransient<IDocumentsRepository, DocumentsRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IEstadoCompeticionRepository, EstadoCompeticionRepository>();
            services.AddTransient<IOperacionCompeticionRepository, OperacionCompeticionRepository>();
            services.AddTransient<ITemporadaJornadaJugadorRepository, TemporadaJornadaJugadorRepository>();
            services.AddTransient<ICuadroCopaRepository, CuadroCopaRepository>();
            services.AddTransient<ITemporadaRondaRepository, TemporadaRondaRepository>();
            ////_logger.LogInformation("Added Ligamania repositories to services");

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<MenuMasterService, MenuMasterService>();
            services.AddTransient<ILigamaniaService, LigamaniaService>();
            services.AddTransient<IAdministradorService, AdministradorService>();
            services.AddTransient<IManagerService, ManagerService>();
            services.AddTransient<IInvitadoService, InvitadoService>();
            services.AddTransient<IPanelControlService, PanelControlService>();
            services.AddTransient<IEntrenadorService, EntrenadorService>();
            services.AddTransient<IHerramientasService, HerramientasService>();
            //_logger.LogInformation("Added Ligamania services to services");

            // Add Automapper
            services.AddAutoMapper(typeof(Startup));
            //_logger.LogInformation("Added Ligamania automapper to services");

            // Add file manager
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            //services.Configure<AppSettingsModel>(Configuration.GetSection("AppSettings"));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services, ILoggerFactory loggerFactory)
        {
            // logging
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                Log.Logger.Information("In Development environment");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else if (env.IsStaging())
            {
                Log.Logger.Information("In Staging environment");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }
            else
            {
                Log.Logger.Information("In Production environment");
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            var locale = Configuration["SiteLocale"];
            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new CultureInfo(locale) },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo(locale) },
                DefaultRequestCulture = new RequestCulture(locale)
            };
            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            // Conectar directamente con un usuario específico
            //if (env.IsDevelopment())
            //{
            //    app.Use(async (context, next) =>
            //    {
            //        var user = context.User.Identity.Name;
            //        DeveloperLogin(context).Wait();
            //        await next.Invoke();
            //    });
            //}

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "/{controller=Home}/{action=Index}/{id?}");
            });

            //CopyOldUsersAndRoles(services).Wait();
            //CreateUserRoles(services).Wait();
            //CreateTemporadaJugador(services).Wait();
            //EliminarTablaEntrenadores(services).Wait();
            //SetLastJornadaEliminado(services).Wait();
            //SetReferenciasCompeticionesCategorias(services).Wait();
            // RECORDATORIO
            // Copiar la tabla temporadacategoriareferencia en una nueva TemporadaCompeticionCategoriaReferencia (script que está en D)

            // Crear la tabla para el menú (via script que está en D)

            //CreateCuadroCopa(services).Wait();
        }
        //private async Task CreateCuadroCopa(IServiceProvider serviceProvider)
        //{
        //    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

        //    var cuadroActual = await dbContext
        //        .TemporadaCuadro
        //        .Include(tc => tc.Competicion) // temporadaCompeticion
        //        .ThenInclude(c => c.Competicion)
        //        .Include(tc => tc.EquipoACategoria) // temporadacompeticioncategoria
        //        .ThenInclude(tc => tc.Categoria)
        //        .Include(tc => tc.EquipoBCategoria)
        //        .ThenInclude(tc => tc.Categoria)
        //        .Where(tc => tc.TemporadaId.Equals(28))
        //        .ToListAsync().ConfigureAwait(false);

        //    foreach (var partidoCuadro in cuadroActual)
        //    {
        //        CompeticionCategoriaDTO compCatA = await dbContext
        //            .CompeticionCategoria
        //            .FirstAsync(cc => cc.Competicion_Id == partidoCuadro.EquipoACategoria.CompeticionId && cc.Categoria_Id == partidoCuadro.EquipoACategoria.CategoriaId).ConfigureAwait(false);
        //        CompeticionCategoriaDTO compCatB = await dbContext
        //            .CompeticionCategoria
        //            .FirstAsync(cc => cc.Competicion_Id == partidoCuadro.EquipoBCategoria.CompeticionId && cc.Categoria_Id == partidoCuadro.EquipoBCategoria.CategoriaId).ConfigureAwait(false);
        //        CuadroCopaDTO nuevoCuadro = new CuadroCopaDTO
        //        {
        //            CompeticionCategoriaEquipoA = compCatA,
        //            CompeticionCategoriaEquipoB = compCatB,
        //            NumPartido = (int)partidoCuadro.NumeroPartido,
        //            Orden = partidoCuadro.Orden,
        //            PuestoPartidoEquipoA = partidoCuadro.EquipoAPuesto,
        //            PuestoPartidoEquipoB = partidoCuadro.EquipoBPuesto,
        //            Ronda = partidoCuadro.Ronda
        //        };
        //        await dbContext.AddAsync(nuevoCuadro).ConfigureAwait(false);
        //    }
        //    await dbContext.SaveChangesAsync().ConfigureAwait(false);
        //}
        //private async Task SetReferenciasCompeticionesCategorias(IServiceProvider serviceProvider)
        //{
        //    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

        //    var referenciasTactual = await dbContext
        //        .TemporadaCompeticionCategoriaReferencia
        //        .Include(tccr => tccr.TemporadaCompeticionCategoria)
        //        .ThenInclude(tcc=>tcc.Temporada)
        //        .Include(tccr => tccr.TemporadaCompeticionCategoria)
        //        .ThenInclude(tcc => tcc.Competicion)
        //        .Include(tccr => tccr.TemporadaCompeticionCategoria)
        //        .ThenInclude(tcc => tcc.Categoria)
        //        .Where(o => o.TemporadaCompeticionCategoria.TemporadaId.Equals(28))
        //        .ToListAsync();

        //    var referenciasPrevias = await dbContext
        //        .TemporadaCompeticionCategoriaReferencia
        //        .Include(tccr => tccr.TemporadaCompeticionCategoria)
        //        .ThenInclude(tcc => tcc.Temporada)
        //        .Where(tccr => tccr.TemporadaCompeticionCategoria.TemporadaId != 28)
        //        .ToListAsync();

        //    foreach(var refe in referenciasTactual)
        //    {
        //        refe.Competicion = refe.TemporadaCompeticionCategoria.Competicion;
        //        refe.Categoria = refe.TemporadaCompeticionCategoria.Categoria;
        //        dbContext.TemporadaCompeticionCategoriaReferencia.Update(refe);
        //    }

        //    dbContext.TemporadaCompeticionCategoriaReferencia.RemoveRange(referenciasPrevias);

        //    await dbContext.SaveChangesAsync(true);
        //}
        //private async Task DeveloperLogin(HttpContext httpContext)
        //{
        //    //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //    var UserManager = httpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
        //    var signInManager = httpContext.RequestServices.GetRequiredService<SignInManager<ApplicationUser>>();

        //    var _user = await UserManager.FindByNameAsync("estela");

        //    await signInManager.SignInAsync(_user, isPersistent: false);

        //}
        //private void MigrateDataBase(IServiceProvider serviceProvider)
        //{
        //    using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
        //    {
        //        context.Database.Migrate();
        //    }
        //}

        //private async Task EliminarTablaEntrenadores(IServiceProvider serviceProvider)
        //{
        //    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //    var users = await UserManager.Users.ToListAsync();
        //    foreach (var user in users)
        //    {
        //        var entrenador = await dbContext.Entrenador.FirstOrDefaultAsync(e => e.Nombre.Equals(user.UserName));
        //        if (entrenador != null)
        //        {
        //            user.IsBot = entrenador.EsBot;
        //            var equipos = await dbContext.Equipo.Where(e => e.Entrenador_Id.Equals(entrenador.Id)).ToListAsync();
        //            user.IsEntrenador = (equipos.Any());
        //            user.UserState = (entrenador.Baja ? eUserState.Removed : eUserState.Confirmed);

        //            await UserManager.UpdateAsync(user);
        //            foreach (var equipo in equipos)
        //            {
        //                equipo.ApplicationUser = user;
        //                dbContext.Equipo.Update(equipo);
        //            }
        //        }
        //    }
        //    await dbContext.SaveChangesAsync(true);
        //}
        //private async Task EliminarTablaEntrenadores(IServiceProvider serviceProvider)
        //{
        //    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //    //var users = await UserManager.Users.ToListAsync();
        //    //foreach (var user in users)
        //    //{
        //    var entrenadores = await dbContext.Entrenador.Where(e=>!e.Nombre.ToUpper().Contains("BOT")).ToListAsync();
        //    foreach (var entrenador in entrenadores)
        //    {
        //        ApplicationUser userToFind = await UserManager.FindByNameAsync(entrenador.Nombre);
        //        if (userToFind == null)
        //        {
        //            var user = new ApplicationUser()
        //            {
        //                City = string.Empty,
        //                CompartirGrupo = string.Empty,
        //                Conocimiento = string.Empty,
        //                Email = entrenador.Email,
        //                PhoneNumber = string.Empty,
        //                EmailConfirmed = true,
        //                UserName = entrenador.Nombre,
        //                UserState = entrenador.Baja ? eUserState.Removed : eUserState.Confirmed,
        //                Whatsap = false,
        //                PasswordHash = HashingPasswords.getHash("ligamania"),
        //                IsBot = entrenador.EsBot,
        //                IsEntrenador = true
        //            };
        //            await UserManager.CreateAsync(user);

        //        }
        //    }

        //    //var entrenadores = await dbContext.Entrenador.Where(e => !e.Nombre.ToUpper().Contains("BOT")).ToListAsync();
        //    foreach (var entrenador in entrenadores)
        //    {
        //        ApplicationUser user = await UserManager.FindByNameAsync(entrenador.Nombre);
        //        if (user != null)
        //        {
        //            var equipos = await dbContext.Equipo.Where(e => e.Entrenador_Id.Equals(entrenador.Id)).ToListAsync();
        //            foreach (var equipo in equipos)
        //            {
        //                equipo.ApplicationUser = user;
        //                dbContext.Equipo.Update(equipo);
        //            }
        //            await UserManager.AddToRoleAsync(user, "Entrenador");
        //            await UserManager.AddToRoleAsync(user, "Invitado");
        //        }
        //    }
        //    await dbContext.SaveChangesAsync(true);
        //}

        //private async Task CreateTemporadaJugador(IServiceProvider serviceProvider)
        //{
        //    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

        //    var jugadoresOld = await dbContext
        //        .OldTemporadaJugador
        //        .Include(oj => oj.Jugador)
        //        .Include(oj => oj.Temporada)
        //        .Where(tj => tj.Temporada.Actual && !tj.Jugador.Baja)
        //        .ToListAsync();

        //    var jugadoresClub = await dbContext
        //            .TemporadaClubJugador
        //            .Include(tcj => tcj.Jugador)
        //            .Include(tcj => tcj.Temporada)
        //            .Include(tcj => tcj.Club)
        //            .Where(tcj => tcj.Activo && tcj.Temporada.Actual)
        //            .ToListAsync();

        //    var jugadoresPuesto = await dbContext
        //            .TemporadaPuestoJugador
        //            .Include(tcj => tcj.Jugador)
        //            .Include(tcj => tcj.Temporada)
        //            .Include(tcj => tcj.Puesto)
        //            .Where(tpj => tpj.Activo && tpj.Temporada.Actual)
        //            .ToListAsync();

        //    foreach (var jugador in jugadoresOld)
        //    {
        //        var jugadorClub = jugadoresClub.FirstOrDefault(jc => jc.JugadorId.Equals(jugador.Jugador.Id));
        //        var jugadorPuesto = jugadoresPuesto.FirstOrDefault(jc => jc.JugadorId.Equals(jugador.Jugador.Id));

        //        if (jugadorClub != null && jugadorPuesto != null)
        //        {
        //            var newJugador = new TemporadaJugador_DTO()
        //            {
        //                Activo = true,
        //                Club = jugadorClub.Club,
        //                Eliminado = jugador.Eliminado,
        //                PreEliminado = jugador.PreEliminado,
        //                Jugador = jugador.Jugador,
        //                Puesto = jugadorPuesto.Puesto,
        //                VecesEliminado = jugador.VecesEliminado,
        //                VecesPreEliminado = jugador.VecesPreEliminado,
        //                Temporada = jugador.Temporada
        //            };
        //            await dbContext.TemporadaJugador.AddAsync(newJugador);
        //        }
        //    }
        //    try
        //    {
        //        await dbContext.SaveChangesAsync(true);
        //    }
        //    catch (Exception x)
        //    {
        //        _logger.LogError($"Error al guardar los jugadores: {x}");
        //    }
        //}

        //private async Task CreateUserRoles(IServiceProvider serviceProvider)
        //{
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //    ////ApplicationUser userEstela = await UserManager.FindByNameAsync("estela");
        //    ////await UserManager.AddToRoleAsync(userEstela, "Manager");

        //    ////return;
        //    IdentityResult roleResult;
        //    //Adding Addmin Role  
        //    //var roleCheck = await RoleManager.RoleExistsAsync("Admin");
        //    //if (!roleCheck)
        //    //{
        //    //    //create the roles and seed them to the database  
        //    //    roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
        //    //}

        //    //roleCheck = await RoleManager.RoleExistsAsync("Manager");
        //    //if (!roleCheck)
        //    //{
        //    //    //create the roles and seed them to the database  
        //    //    roleResult = await RoleManager.CreateAsync(new IdentityRole("Manager"));
        //    //}

        //    //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
        //    //ApplicationUser user = await UserManager.FindByEmailAsync("egonzalez72@gmail.com");
        //    ApplicationUser user = await UserManager.FindByNameAsync("estela");
        //    if (user == null)
        //    {
        //        var User = new ApplicationUser()
        //        {
        //            City = "Siero",
        //            CompartirGrupo = string.Empty,
        //            Conocimiento = "web",
        //            Email = "egonzalez72@gmail.com",
        //            //Equipo = string.Empty,
        //            PhoneNumber = "677450165",
        //            EmailConfirmed = true,
        //            UserName = "estela",
        //            UserState = eUserState.Confirmed,
        //            Whatsap = false,
        //            PasswordHash = HashingPasswords.getHash("carcaba51")
        //        };
        //        await UserManager.CreateAsync(User);

        //        await UserManager.AddToRoleAsync(User, "Admin");
        //        await UserManager.AddToRoleAsync(User, "Manager");
        //        await UserManager.AddToRoleAsync(User, "Entrenador");
        //        await UserManager.AddToRoleAsync(User, "Invitado");
        //        await UserManager.AddToRoleAsync(User, "Master");
        //        await UserManager.AddToRoleAsync(User, "Super");
        //    }
        //}
        //private async Task CopyOldUsersAndRoles(IServiceProvider serviceProvider)
        //{
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

        //    // por cada elemento de la tabla 'oldAspNetRoles' vamos a crear el mismo en la tabla AspNetRoles
        //    var roles = await dbContext.OldRoles.ToListAsync();
        //    foreach (var rol in roles)
        //    {
        //        await RoleManager.CreateAsync(new IdentityRole(rol.Name));
        //    }
        //    var users = await dbContext.OldUsers.ToListAsync();
        //    foreach (var user in users)
        //    {
        //        var newUser = new ApplicationUser()
        //        {
        //            City = user.City,
        //            CompartirGrupo = user.CompartirGrupo,
        //            Conocimiento = user.Conocimiento,
        //            Email = user.Email,
        //            PhoneNumber = user.PhoneNumber,
        //            EmailConfirmed = user.EmailConfirmed,
        //            UserName = user.UserName,
        //            UserState = user.UserState,
        //            Whatsap = user.Whatsap,
        //            PasswordHash = user.PasswordHash,
        //            SecurityStamp = user.SecurityStamp
        //        };
        //        var result = await UserManager.CreateAsync(newUser);
        //        if (result.Succeeded)
        //        {
        //            _logger.LogDebug($"User copied: {newUser.UserName} - {newUser.Email} ");
        //        }
        //        else
        //        {
        //            _logger.LogError($"User not copied: {newUser.UserName} - {newUser.Email} - {result.Errors}");
        //        }
        //    }
        //    var rolUsers = await dbContext.OldUserRoles.ToListAsync();
        //    foreach (var rolUser in rolUsers)
        //    {
        //        if (!string.IsNullOrWhiteSpace(rolUser.User.Email))
        //        {
        //            var user = await UserManager.FindByEmailAsync(rolUser.User.Email);
        //            if (user != null)
        //                await UserManager.AddToRoleAsync(user, rolUser.Role.Name);
        //        }
        //    }
        //}

        //private async Task SetLastJornadaEliminado(IServiceProvider serviceProvider)
        //{
        //    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

        //    var temporadaJugador = dbContext.TemporadaJugador
        //        .Include(tj => tj.Temporada)
        //        .Include(tj => tj.Jugador)
        //        .Where(tj => tj.Temporada.Actual && tj.Activo && tj.Eliminado)
        //        .ToList();

        //    foreach (var jugador in temporadaJugador)
        //    {
        //        var temporadajornadajugador = dbContext.TemporadaJornadaJugador
        //            .Include(tjj => tjj.Temporada)
        //            .Include(tjj => tjj.Jugador)
        //            .Include(tjj => tjj.Jornada)
        //            .Where(tjj => tjj.Temporada.Actual && tjj.JugadorId.Equals(jugador.Jugador.Id) && tjj.Eliminado)
        //            .OrderByDescending(tjj => tjj.Jornada.NumeroJornada)
        //            .FirstOrDefault();
        //        var temporadaCompeticionJornada = dbContext.TemporadaCompeticionJornada
        //            .Where(tcj => tcj.Temporada.Actual && tcj.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga) && tcj.NumeroJornada.Equals(temporadajornadajugador.Jornada.NumeroJornada))
        //            .FirstOrDefault();
        //        jugador.LastJornadaEliminacion = temporadaCompeticionJornada;
        //        dbContext.Update(jugador);
        //    }
        //    await dbContext.SaveChangesAsync();
        //}
    }
}
