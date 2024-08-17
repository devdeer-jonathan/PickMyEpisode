using devdeer.Libraries.Abstractions.Interfaces;

using Logic.Interfaces.Logic;
using Logic.Interfaces.Repositories;

using Microsoft.Extensions.DependencyInjection;
using devdeer.Libraries.Abstractions.Extensions;

using Logic.Core;

using Microsoft.Extensions.Hosting;

using Repositories.TvMaze;

using Ui.Console;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // TODO add your service dependencies here
        services.AddTransient<ITelevisionShowRepository, TelevisionShowRepository>();
        services.AddTransient<ITelevisionShowLogic, TelevisionShowLogic>();
        services.AddHttpClient<IJsonRestClient, TvMazeRestClient>();
        services.AddSingleton<App>();
    });
var app = builder.Build();
return await app.Services.GetRequiredService<App>().StartAsync(Environment.GetCommandLineArgs());