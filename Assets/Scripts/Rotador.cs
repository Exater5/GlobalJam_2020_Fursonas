using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{

    public Vector3 direccionRotacion;
    float multiplicador;
    // Update is called once per frame
    void Update()
    {
        if (Time.time <= 5)
        {
            multiplicador = +Time.time;
        }
        transform.Rotate(direccionRotacion * multiplicador * Time.deltaTime);
    }
}
