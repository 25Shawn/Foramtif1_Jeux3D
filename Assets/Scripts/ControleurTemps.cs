using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Gère la vitesse de la simulation
/// </summary>
public class ControleurTemps : MonoBehaviour
{
    public static ControleurTemps Instance { get; private set; }

    [SerializeField, Tooltip("Vitesse la plus lente de la simulation")]
    private float ratioMinimal;

    [SerializeField, Tooltip("Vitesse la plus rapide de la simulation")]
    private float ratioMaximal;

    [SerializeField, Tooltip("Ratio de la simulation, indique la valeur initiale de la vitesse de simulation")]
    private float ratioTemps;

    [SerializeField, Tooltip("Étiquette pour afficher la vitesse de simulation")]
    private TextMeshProUGUI etiquetteRatio;

    [SerializeField, Tooltip("Curseur pour modifier la vitesse de simulation")]
    private Slider curseurRatioTemps;

    /// <summary>
    /// Ratio du nombre d'années par seconde dans la simultation
    /// </summary>
    public float RatioTemps => ratioTemps;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        curseurRatioTemps.onValueChanged.AddListener(ValeurTempsModifie);
        curseurRatioTemps.value = Mathf.InverseLerp(ratioMinimal, ratioMaximal, ratioTemps);
        
    }

    /// <summary>
    /// Modifie le ratio du temps selon une valeur indiquant le pourcentage de la vitesse de la simulation.
    /// </summary>
    /// <param name="pourcentageVitesse">Indique le pourcentage de la vitesse maximale à laquelle la
    /// simulation s'exécute.</param>
    public void ValeurTempsModifie(float pourcentageVitesse)
    {
        ratioTemps = Mathf.Lerp(ratioMinimal, ratioMaximal, pourcentageVitesse);
        etiquetteRatio.text = $"1 seconde = {ratioTemps:F1} année{(ratioTemps >= 2.0f ? "s" : "")}";
    }
}
