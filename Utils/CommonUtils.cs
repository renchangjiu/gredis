using System;
using System.Diagnostics;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Styling;

namespace gredis.Utils;

public static class CommonUtils {

    /// <param name="path">like: /Assets/icon.ico</param>
    public static Bitmap GetBitmapFromAsset(string path) {
        Stream fs = AssetLoader.Open(new Uri($"avares://gredis{path}"));
        Bitmap ret = new(fs);
        fs.Dispose();
        return ret;
    }

    public static ThemeVariant GetThemeVariant(string value) {
        switch (value) {
            case nameof(ThemeVariant.Light):
                return ThemeVariant.Light;
            case nameof(ThemeVariant.Dark):
                return ThemeVariant.Dark;
            default:
                return ThemeVariant.Default;
        }
    }
    public static void OpenBrowser(string url) {
        Process.Start(new ProcessStartInfo() {
            FileName = url,
            UseShellExecute = true,
            Verb = "open"
        });
    }

}