using System;
using System.Windows.Controls;

namespace DemoBinding.Utils;

public interface INavigator
{
    ContentControl CurrentContentControl { get; set; }

    void RegisterView(Control view);

    void NavigateTo(Type type);

    void Back();

    bool CanGoBack();
}