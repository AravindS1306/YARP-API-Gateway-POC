using JwtAuthExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddJwtAuth(builder.Configuration); //Extensions method compiled as a dll to avoid repeated code

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapReverseProxy(); // Map the reverse proxy to handle incoming requests and forward them to the appropriate backend services    


app.Run();
