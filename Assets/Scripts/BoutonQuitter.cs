using UnityEngine;

/// <summary>
/// Bouton pour quitter la simulation
/// </summary>
public class BoutonQuitter : MonoBehaviour
{
    /// <summary>
    /// Force l'application à quitter
    /// </summary>
    public void QuitterApplication()
    {
        Application.Quit();
    }
}
