using ColegioApp.Business;
using ColegioApp.Data.Interfaces;
using ColegioApp.Data.Repository;
using ColegioApp.Entity.Context;
using ColegioApp.Utilities.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ============================================
// CONFIGURACIÓN BASE
// ============================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ============================================
// 🔐 CONFIGURACIÓN JWT
// ============================================
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// ============================================
// 🧭 SWAGGER + JWT AUTHORIZACIÓN
// ============================================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Colegio API",
        Version = "v1",
        Description = "API del sistema ColegioApp con autenticación JWT"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT en este formato: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// ============================================
// 💾 CONEXIÓN DB (SQL SERVER)
// ============================================
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ============================================
// 🧩 DEPENDENCIAS (DI)
// ============================================
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddScoped<ProfesorService>();
builder.Services.AddScoped<CursoService>();
builder.Services.AddScoped<MateriaService>();
builder.Services.AddScoped<NotaService>();
builder.Services.AddScoped<PeriodoService>();

// ============================================
// 🗺️ AUTOMAPPER
// ============================================
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// ============================================
// CONSTRUIR APP
// ============================================
var app = builder.Build();

// ============================================
// PIPELINE MIDDLEWARE
// ============================================
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// 🔐 Autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
