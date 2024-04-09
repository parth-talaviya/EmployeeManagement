var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new List<string>()
        }
    });
});

var logDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Error_Log");
var logFilePath = Path.Combine(logDirectoryPath, "log.txt");
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day, shared: true)
    .CreateLogger();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateUserHandler).Assembly));
builder.Services.AddCustomServices(typeof(User).Assembly);
builder.Services.AddCustomServices(typeof(UserRepository).Assembly);
builder.Services.AddCustomServices(typeof(UserService).Assembly);
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddOptions<SqlConnectionOptionsDto>()
    .BindConfiguration("SqlConnection")
    .ValidateDataAnnotations().ValidateOnStart();
builder.Services.AddOptions<JwtConnectionOptionsDto>()
    .BindConfiguration("Jwt")
    .ValidateDataAnnotations().ValidateOnStart();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddValidatorsFromAssemblyContaining<UserViewModelValidator>();
builder.Services.AddAuthorizationBuilder().AddPolicy("AdminPolicy", policy => { policy.RequireRole("Admin"); });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.RegisterEndpoints();

app.Run();