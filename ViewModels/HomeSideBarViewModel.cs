using System;
using Avalonia;
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;
using gredis.Views;

namespace gredis.ViewModels;

public class HomeSideBarViewModel : ViewModelBase {

    public HomeSideBarViewModel() {
        Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
    }

    public async void HandleNewConn() {
        ContentDialog dialog = new() {
            Title = "New connection",
            PrimaryButtonText = "Ok",
            SecondaryButtonText = "Apply",
            CloseButtonText = "Cancel",
        };
        ConnAddViewModel vm = new(dialog);
        ConnAddView view = new() {
            DataContext = vm
        };
        dialog.Content = view;
        ContentDialogResult res = await dialog.ShowAsync();
        Console.WriteLine(res);
    }

}