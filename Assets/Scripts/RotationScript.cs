using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class MercureScript : MonoBehaviour
{

    // Les variables de rotations
    [SerializeField]
    private Transform centrePlanete;

    [SerializeField]
    private float revolution;

    /// <summary>
    /// Fonction qui gère la rotation des planetes ou des lunes avec son parent
    /// </summary>
    private void Update()
    {
        float ratioTemps = ControleurTemps.Instance.RatioTemps;
        float vitesseRotation = (360f / revolution)* ratioTemps;



        transform.RotateAround(centrePlanete.position, Vector3.up, vitesseRotation);
    }
}
