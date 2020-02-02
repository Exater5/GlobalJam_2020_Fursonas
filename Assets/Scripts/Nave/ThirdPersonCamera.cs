using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;

    public const float yMinAngle = -50;
    public const float yMaxAngle = 65f;
    public float sensibilidadHorizontal = 1f;
    public float sensibilidadVertical = 1f;
    float distance = 10f;

    float currentX;
    float currentY;
    float x;
    float y;
    float initialx;
    float initialy;

    Vector3 distancia;
    Quaternion rotacionCamara;
    Quaternion rotacionHuevo;
    Quaternion encuadre;

    bool cuadrando = false;
    bool girando = false;
    bool puedeGirar = false;
    void Start()
    {
        distancia = new Vector3(0, 0, -distance);
        rotacionCamara = Quaternion.Euler(25, lookAt.rotation.eulerAngles.y, 0);
        transform.position = lookAt.position + rotacionCamara * distancia;
        transform.LookAt(lookAt);
        currentX = 0;
        currentY = 25;
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if(x+y == 0)
        {
            /*
            if (Input.GetMouseButton(1))
            {
                Vector2 mouse = new Vector2(Camera.main.ScreenToViewportPoint(Input.mousePosition).x, Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
                currentX += (mouse.x * sensibilidadHorizontal);
                currentY += (mouse.y * sensibilidadVertical);
                currentY = Mathf.Clamp(currentY, yMinAngle, yMaxAngle);
            }
            */
        }
        else
        {
            currentX += (x * sensibilidadHorizontal) * -1;
            currentY += (y * sensibilidadVertical);
            currentY = Mathf.Clamp(currentY, yMinAngle, yMaxAngle);
        }
        if(distance <= 3 )
        {
            distance = 3;
        }
        if(distance >= 10)
        {
            distance = 10;
        }
        distance = distance - (Input.GetAxis("Mouse ScrollWheel") * 3);
        distancia = new Vector3(0, 0, -distance);
        Rotador();
    }

    void Rotador()
    {
        rotacionCamara = Quaternion.Euler(currentY - initialx, currentX + initialy, 0);
        transform.position = lookAt.position + rotacionCamara * distancia;

        transform.LookAt(lookAt);
    }
}
