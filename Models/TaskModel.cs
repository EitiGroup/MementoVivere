namespace MementoVivere.Models;

/// <summary>
/// Représente une tâche à accomplir par l'utilisateur.
/// </summary>
public class TaskModel
{
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public int XpReward { get; set; }
}
