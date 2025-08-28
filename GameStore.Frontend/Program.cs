using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

//specifying the url we are using for backend
var gameStoreAppUrl = builder.Configuration["GameStoreApiUrl"] ??
        throw new Exception("GameStoreApiUrl is not set");
//registering DI
builder.Services.AddHttpClient<GamesClient>(client =>
    client.BaseAddress = new Uri(gameStoreAppUrl));
builder.Services.AddHttpClient<GenresClient>(client =>
    client.BaseAddress = new Uri(gameStoreAppUrl));

// Adding DI services
// builder.Services.AddSingleton<GamesClient>();
// builder.Services.AddSingleton<GenresClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
