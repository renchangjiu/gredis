using System;
using System.Globalization;
using Avalonia.Styling;
using gredis.Components;

namespace gredis.ViewModels;

public class MainWindowViewModel : ViewModelBase {

    public MainWindowViewModel() {
        Settings settings = Apps.getService<Settings>();
    }

}