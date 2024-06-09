using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddBff();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "cookie";
        options.DefaultChallengeScheme = "oidc";
        options.DefaultSignOutScheme = "oidc";
    })
        .AddCookie("cookie", options =>
        {
            options.Cookie.Name = "__Host-bff";
            options.Cookie.SameSite = SameSiteMode.Strict;
        })
        .AddOpenIdConnect("oidc", options =>
        {
            options.Authority = builder.Configuration["OpenIdConfig:Authority"];
            options.ClientId = builder.Configuration["OpenIdConfig:ClientId"];
            options.ClientSecret = builder.Configuration["OpenIdConfig:Secret"];
            options.CallbackPath = new PathString(builder.Configuration["OpenIdConfig:CallbackPath"]);
            options.ResponseType = "code";
            options.ResponseMode = "query";

            options.GetClaimsFromUserInfoEndpoint = true;
            options.MapInboundClaims = false;
            options.SaveTokens = true;

            options.Scope.Clear();
            options.Scope.Add("openid");
            options.Scope.Add("profile");
        });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnetion = builder.Configuration["ConnectionStrings:DefaultConnection"]!;

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(dbConnetion)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseBff();

app.UseAuthorization();

app.MapControllers().RequireAuthorization().AsBffApiEndpoint();

app.MapBffManagementEndpoints();

app.MapFallbackToFile("index.html");

app.Run();
