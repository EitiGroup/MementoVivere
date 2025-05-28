using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MementoVivere.ViewModels;

namespace MementoVivere.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Ouvre une boîte de dialogue pour ajouter une nouvelle tâche.
    /// </summary>
    private async void AddTaskButton_Click(object? sender, RoutedEventArgs e)
    {
        var dialog = new Window
        {
            Title = "Ajouter une tâche",
            Width = 350,
            Height = 150,
            Content = new StackPanel
            {
                Margin = new Thickness(16),
                Spacing = 8,
                Children =
                {
                    new TextBlock { Text = "Titre de la tâche :" },
                    new TextBox { Name = "TaskTitleBox" },
                    new Button { Content = "Ajouter", Name = "AddBtn", Width = 100, HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right }
                }
            }
        };
        var textBox = ((dialog.Content as StackPanel)!.Children[1] as TextBox)!;
        var addBtn = ((dialog.Content as StackPanel)!.Children[2] as Button)!;
        string? result = null;
        addBtn.Click += (_, _) => { result = textBox.Text; dialog.Close(); };
        await dialog.ShowDialog(this);
        if (!string.IsNullOrWhiteSpace(result) && DataContext is MainWindowViewModel vm)
        {
            vm.AddTaskCommand.Execute(result);
        }
    }
}