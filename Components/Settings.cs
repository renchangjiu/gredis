using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using gredis.Utils;
using NLog;

namespace gredis.Components;

public class Settings {

    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    public ConfigC Config { get; private set; }

    private readonly FileInfo dest;

    public Settings() {
        dest = new FileInfo(Path.Combine(Apps.getDataPath(), "settings.json"));
        if (!dest.Exists) {
            dest.Create();
        }

        load();
        autoSave();
    }

    private void autoSave() {
        Task task = new(() => {
            save();
            Log.Debug("auto save settings");
            Task.Delay(TimeSpan.FromMinutes(2)).Wait();
        }, TaskCreationOptions.LongRunning);

        task.Start();
    }

    public void save() {
        string json = JsonSerializer.Serialize(Config, CC.JsonSerializerOptions);
        File.WriteAllText(dest.FullName, json, Encoding.UTF8);
    }


    private void load() {
        string json = File.ReadAllText(dest.FullName, Encoding.UTF8);
        if (string.IsNullOrWhiteSpace(json)) {
            Config = new ConfigC();
            return;
        }

        Config = JsonSerializer.Deserialize<ConfigC>(json)!;
    }


    public class ConfigC {

        public string Theme { get; set; }

        public string Version { get; set; }

    }

}