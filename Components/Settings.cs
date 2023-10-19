using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Styling;
using gredis.Utils;
using NLog;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace gredis.Components;

public class Settings : ReactiveObject {

    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    [Reactive]
    public Config0 Config { get; private set; }

    private readonly FileInfo dest;

    public Settings() {
        dest = new FileInfo(Path.Combine(Apps.getDataPath(), "settings.json"));
        if (!dest.Exists) {
            dest.Create();
        }

        load();
        autoSave();
        this.WhenAnyValue(vm => vm.Config.Theme)
            .Subscribe(item => { save(); });
    }

    private void autoSave() {
        Task task = new(() => {
            save();
            Log.Debug("setting auto saved.");
            Task.Delay(TimeSpan.FromMinutes(2)).Wait();
        }, TaskCreationOptions.LongRunning);

        task.Start();
    }

    private void save() {
        string json = JsonSerializer.Serialize(Config, CC.JsonSerializerOptions);
        File.WriteAllText(dest.FullName, json, Encoding.UTF8);
        Log.Debug("setting saved.");
    }


    private void load() {
        string json = File.ReadAllText(dest.FullName, Encoding.UTF8);
        if (string.IsNullOrWhiteSpace(json)) {
            Config = BuildDefaultConfig();
            return;
        }

        Config = JsonSerializer.Deserialize<Config0>(json)!;
    }

    private static Config0 BuildDefaultConfig() {
        Config0 c = new();
        c.Theme = ThemeVariant.Dark.ToString();
        c.Version = CC.Version;
        c.Connections = new List<Connection>();

        return c;
    }

}

public class Config0 : ReactiveObject {

    [Reactive]
    public string Theme { get; set; }

    public string Version { get; set; }

    public List<Connection> Connections { get; set; }

}

public class Connection : ReactiveObject {

    public string Host { get; set; }
    public string Port { get; set; }
    public string Password { get; set; }

}