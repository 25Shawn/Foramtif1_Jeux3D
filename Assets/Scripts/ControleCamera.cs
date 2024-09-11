using UnityEngine;
using UnityEngine.InputSystem;

public class ControleCamera : MonoBehaviour
{

    // Les variables utiliser pour le deplacemnt 
    [SerializeField]
    private float vitesse;

    private Vector2 deplacement;


    // Les variables utiliser pour le zoom
    [SerializeField]
    private float zoomMax = 30;
    [SerializeField]
    private float zoomMin = 90;
    [SerializeField]
    private float zoomVitesse = 10f;

    private float zoomInput;


    // Les variables utiliser pour l'inclinaison
    [SerializeField]
    private float inclinaisonMax = 45F;
    [SerializeField]
    private float inclinaisonMin = -45F;
    [SerializeField]
    private float inclinaisonVitesse = 30F;

    private float inclinaisonInput;


    /// <summary>
    /// Fonction qui va chercher le input du déplacement du InputAction
    /// </summary>
    /// <param name="contexte">le input choisi donc w,a,s,d </param>
    public void Move(InputAction.CallbackContext contexte)
    {
        deplacement = contexte.action.ReadValue<Vector2>();
    }

    /// <summary>
    /// Fonction qui va chercher le input du zoom dans le InputAction 
    /// </summary>
    /// <param name="contexte">le input choisi donc z,x </param>
    public void Zoom(InputAction.CallbackContext contexte)
    {
        zoomInput = contexte.ReadValue<float>();
    }

    /// <summary>
    /// Fonction qui va chercher le input de l'inclinaison dans le InputAction
    /// </summary>
    /// <param name="contexte">le input choisi donc c,v </param>
    public void Inclinaison(InputAction.CallbackContext contexte)
    {
        inclinaisonInput = contexte.ReadValue<float>();
    }

    /// <summary>
    /// 
    /// Fonction qui gère l'inclinaison, du zoom et du deplacement de la camera.
    /// 
    /// </summary>
    private void FixedUpdate()
    {

        // Calcule de la l'inclinaison de la camera
        Vector3 rotation = Camera.main.transform.localEulerAngles;
        float newInclinaison = Mathf.Clamp(rotation.x + (inclinaisonInput * inclinaisonVitesse * Time.deltaTime), inclinaisonMin, inclinaisonMax);
        Camera.main.transform.localEulerAngles = new Vector3(newInclinaison, rotation.y, rotation.z);


        // Calcule du Zoom de la camera
        float nouveauZoom = Camera.main.fieldOfView - (zoomInput * zoomVitesse * Time.deltaTime);
        Camera.main.fieldOfView = Mathf.Clamp(nouveauZoom, zoomMax, zoomMin);

        // Calcule du deplacement de la camera
        Vector3 deplacementEffectif = (deplacement.y * transform.forward + deplacement.x * transform.right).normalized;
        transform.position += deplacementEffectif * vitesse * Time.deltaTime;
    }
}
