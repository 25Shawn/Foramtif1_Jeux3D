using UnityEngine;
using UnityEngine.UI;

public class MercureScript : MonoBehaviour
{

    // Les variables de rotations
    [SerializeField]
    private Transform centrePlanete; 

    [SerializeField]
    private float rayonRotation = 10f; 

    private float angle; 

    [SerializeField]
    private Slider curseurRatioTemps;

    [SerializeField]
    private float ratioTemps;

    private const float JoursParAn = 365f;

    private float rotationVitesse = 1000f;

    /// <summary>
    /// Fonction qui gère la direction de la rotation au depart du jeu
    /// </summary>
    private void Start()
    {
        // calcule qui va chercher la direction de la rotation initiale
        Vector3 directionInitiale = (transform.position - centrePlanete.position).normalized;
        transform.position = centrePlanete.position + directionInitiale * rayonRotation;
    }
    /// <summary>
    /// Fonction qui gère la rotation des planetes ou des lunes avec son parent
    /// </summary>
    private void Update()
    {

        float ratioTempsEnJours = curseurRatioTemps.value * JoursParAn;

        //calcule de la rotation
        float facteurRotation = (ratioTempsEnJours / ratioTemps)* rotationVitesse;
        transform.RotateAround(centrePlanete.position, Vector3.up, facteurRotation * Time.deltaTime);
    }
}
