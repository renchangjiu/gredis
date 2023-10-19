using System;
using System.IO;
using gredis.Components;
using gredis.Configs;
using gredis.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace gredis;

public class Apps {

    private static ServiceProvider _serviceProvider;

    public static ServiceProvider ServiceProvider {
        get => _serviceProvider;
        private set => _serviceProvider = value;
    }


    public static T getService<T>() where T : notnull {
        return ServiceProvider.GetRequiredService<T>();
    }

    public static object getService(Type type) {
        return ServiceProvider.GetRequiredService(type);
    }

    public static void init() {
        NLogConfig.init();
        buildServiceProvider();
        if (!Path.Exists(getDataPath())) {
            Directory.CreateDirectory(getDataPath());
        }
    }

    private static void buildServiceProvider() {
        ServiceCollection co = new();

        co.AddSingleton<Settings>();

        co.AddSingleton<HomeViewModel>();
        co.AddSingleton<SettingViewModel>();

        co.AddSingleton<MainViewModel>();
        co.AddSingleton<MainWindowViewModel>();


        ServiceProvider = co.BuildServiceProvider();
    }

    public static string getDataPath() {
        return Path.Combine(Environment.CurrentDirectory, "data");
    }

}