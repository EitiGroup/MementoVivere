namespace MementoVivere.Services;

/// <summary>
/// Service pour gérer l'expérience et les niveaux.
/// </summary>
public class XpService
{
    private const int XpPerLevel = 100;

    /// <summary>
    /// Ajoute de l'XP et retourne le nouveau niveau.
    /// </summary>
    public int AddXp(ref int currentXp, int toAdd)
    {
        currentXp += toAdd;
        return GetLevel(currentXp);
    }

    /// <summary>
    /// Calcule le niveau à partir de l'XP.
    /// </summary>
    public int GetLevel(int xp)
    {
        return xp / XpPerLevel + 1;
    }
}
