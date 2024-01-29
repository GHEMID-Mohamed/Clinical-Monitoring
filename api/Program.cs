using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddBff();
// builder.Services.AddAuthentication(options =>
//     {
//         options.DefaultScheme = "cookie";
//         options.DefaultChallengeScheme = "oidc";
//         options.DefaultSignOutScheme = "oidc";
//     })
//         .AddCookie("cookie", options =>
//         {
//             options.Cookie.Name = "__Host-bff";
//             options.Cookie.SameSite = SameSiteMode.Strict;
//         })
//         .AddOpenIdConnect("oidc", options =>
//         {
//             options.Authority = "https://dev-oimot0xnw5tnqrqh.us.auth0.com";
//             options.ClientId = "IrI9gqE6rEyEUgC7hLSWcOzl0Db2Xlw3";
//             options.ClientSecret = "713WxDhUH5zC9hhZkkgww5-ReXSEHuHmliF7_3DTzgbyzSXsM5lXxs_ycvfZp48S";
//             options.CallbackPath = new PathString("/clinical-monitoring-callback");
//             options.ResponseType = "code";
//             options.ResponseMode = "query";

//             options.GetClaimsFromUserInfoEndpoint = true;
//             options.MapInboundClaims = false;
//             options.SaveTokens = true;

//             options.Scope.Clear();
//             options.Scope.Add("openid");
//             options.Scope.Add("profile");
//             options.Scope.Add("api");
//             options.Scope.Add("offline_access");
//         });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnetion = builder.Configuration["ConnectionStrings:DefaultConnection"]!;

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(dbConnetion)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseAuthentication();

// app.UseBff();

app.UseAuthorization();

// app.MapControllers().RequireAuthorization().AsBffApiEndpoint();

app.MapControllers();

app.MapBffManagementEndpoints();

app.Run();
