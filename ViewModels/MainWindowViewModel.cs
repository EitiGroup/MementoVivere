using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MementoVivere.Models;
using MementoVivere.Services;

namespace MementoVivere.ViewModels;

/// <summary>
/// ViewModel principal pour la gestion des tâches, XP, et niveau utilisateur.
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// Liste observable des tâches de l'utilisateur.
    /// </summary>
    public ObservableCollection<TaskModel> Tasks { get; } = new();

    /// <summary>
    /// Modèle utilisateur (XP, niveau).
    /// </summary>
    [ObservableProperty]
    private UserModel user = new() { Experience = 0, Level = 1 };

    private readonly XpService xpService = new();

    public MainWindowViewModel()
    {
        // Exemple de tâche initiale
        Tasks.Add(new TaskModel { Title = "Créer une première tâche", XpReward = 20, IsCompleted = false });
    }

    /// <summary>
    /// Commande pour valider la première tâche non complétée.
    /// </summary>
    [RelayCommand]
    private void ValidateTask()
    {
        var task = Tasks.FirstOrDefault(t => !t.IsCompleted);
        if (task != null)
        {
            task.IsCompleted = true;
            // Correction : on ne peut pas passer User.Experience en ref car c'est une propriété auto-implémentée
            var xp = User.Experience;
            User.Level = xpService.AddXp(ref xp, task.XpReward);
            User.Experience = xp;
            OnPropertyChanged(nameof(User));
        }
    }

    /// <summary>
    /// Commande pour ajouter une nouvelle tâche (titre passé en paramètre).
    /// </summary>
    [RelayCommand]
    private void AddTask(string? title)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            Tasks.Add(new TaskModel { Title = title, XpReward = 10, IsCompleted = false });
        }
    }
}

