using gredis.ViewModels;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace gredis.Models;

public class NavMenuItem : ReactiveObject {

    [Reactive]
    public string Content { get; set; }

    [Reactive]
    public string IconSource { get; set; }

    public ViewModelBase? Page { get; set; }

}