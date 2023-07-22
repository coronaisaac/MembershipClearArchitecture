var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region Swagger Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Auth WEB API",
        Version = "v1"
    });
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
    options.AddSecurityDefinition("BearerToken", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Proporcionar el valor del token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(
    new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "BearerToken"
                }
            },
            Array.Empty<string>()
        }
    });
    
});
#endregion Swagger Configuration

#region Memebership Configuration
builder.Services
    .AddMembershipCoreServices(jwtOptions =>
            builder.Configuration
                .GetSection(JwtOptions.SectionKey)
                .Bind(jwtOptions))
    .AddMembershipValidators()
    .AddMembershipMessageLocalizer()
    .AddRefreshTokenMemoryCacheService()
    .AddUserManagerAspNetIdentityService(aspNetIdentityOptions =>
            builder.Configuration
                .GetSection(aspNetIdentityOptions.SectionKey)
                .Bind(aspNetIdentityOptions));
#endregion Memebership Configuration

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyHeader();
        pol.AllowAnyMethod();
        pol.AllowAnyOrigin();
    });
});

#region Authentication Schema Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        builder.Configuration.GetSection(JwtOptions.SectionKey)
        .Bind(opt.TokenValidationParameters);
        opt.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection(JwtOptions.SectionKey)["SecurityKey"]));
        if (int.TryParse(builder.Configuration.GetSection(JwtOptions.SectionKey)["ClockSkewInMinutes"], out int value))
        {
            opt.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(value);
        }
    });
#endregion Authentication Schema Configuration

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseMembershipExceptionHandler();
// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();
//Configurations extras
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
//Added Endpoints from Membership
app.UseMembershipEndpoints();

app.MapGet("/autorizeduser", (HttpContext context, IUserService user) => Results.Ok($"Hello {user.FullName} {user.Email} - {context.User.Identity.Name}"))
    .RequireAuthorization();
app.MapGet("/anonymous", () => Results.Ok("Hello, World!"));

app.Run();

