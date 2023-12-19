using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    /* La cam�ra reste � une distance constante au-dessus du sol (�l�ments de groundLayer), et se d�place lorsque le curseur s'approche des bords de l'�cran.
     * */

    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask groundLayer; // Layer contenant le sol
    [SerializeField] private float groundDistance;  // Distance au sol de la cam�ra
    [SerializeField] private float cameraSpeed; // Vitesse de d�placement de la cam�ra (uu/s)
    [SerializeField, Range(0.0f, 1.0f)] private float screenLimitDistance;  // Taille des bordures de l'�cran dans lesquelles on fait d�placer la cam�ra 
    // (par ex : le curseur de situe dans les 5% de l�cran le plus � gauche)
    [SerializeField] private Transform minBoundary; // Transform se situant en position (Xmin, Ymin) d'o� peut se d�placer la cam�ra
    [SerializeField] private Transform maxBoundary; // Transform se situant en position (Xmax, Ymax) d'o� peut se d�placer la cam�ra
    [SerializeField] private float smoothSpeed;  // Facteur rendant les mouvements de cam�ra plus smooth

    private Vector3 rightVector; // Vecteur que suit la cam�ra lorsque le curseur est � droite
    private Vector3 upVector;   // Vecteur que suit la cam�ra lorsque le curseur est en haut
    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        rightVector = _camera.transform.right;
        upVector = Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up).normalized;

        minX = minBoundary.position.x;
        maxX = maxBoundary.position.x;
        minZ = minBoundary.position.z;
        maxZ = maxBoundary.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }


    void updatePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 relMousePos = new Vector3(Mathf.Clamp01(mousePos.x / Screen.width), Mathf.Clamp01(mousePos.y / Screen.height), 0);

        Vector3 curPos = _camera.transform.position;
        Vector3 newPos = curPos;

        if (relMousePos.x < screenLimitDistance)
        {
            newPos -= rightVector * cameraSpeed * Time.deltaTime;
        }

        if (relMousePos.x > 1 - screenLimitDistance)
        {
            newPos += rightVector * cameraSpeed * Time.deltaTime;
        }

        if (relMousePos.y < screenLimitDistance)
        {
            newPos -= upVector * cameraSpeed * Time.deltaTime;
        }

        if (relMousePos.y > 1 - screenLimitDistance)
        {
            newPos += upVector * cameraSpeed * Time.deltaTime;
        }

        newPos = new Vector3(Mathf.Clamp(newPos.x, minX, maxX), newPos.y, Mathf.Clamp(newPos.z, minZ, maxZ));

        RaycastHit hit;

        if(Physics.Raycast(newPos, Vector3.down, out hit, 1000, groundLayer.value))
        {
            newPos.y = hit.point.y + groundDistance;
        }

        // Debug.Log(curPos);

        _camera.transform.position = Vector3.Lerp(curPos, newPos, smoothSpeed * Time.deltaTime);
    }
}
