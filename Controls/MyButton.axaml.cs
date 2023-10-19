using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using gredis.Components;
using ReactiveUI;

namespace gredis.Controls;

public partial class MyButton : UserControl {

    private Settings settings { get; }

    public MyButton() {
        InitializeComponent();
        settings = Apps.getService<Settings>();

        this.WhenAnyValue(btn => btn.settings.Config.Theme)
            .Subscribe(theme => { Console.WriteLine(theme); });
    }

}