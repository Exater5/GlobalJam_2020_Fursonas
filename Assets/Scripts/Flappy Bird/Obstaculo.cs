using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{

    public float velocidadInicial = 1.0f;
    float velocidad = 1.0f;
    public float kamikaze = 1.0f;


    private void Start()
    {
        Destroy(gameObject, kamikaze);
        velocidad = velocidadInicial * 2.0f;
    }

    void Update()
    {
        transform.position = transform.position + Vector3.left * velocidadInicial * Time.deltaTime;
    }
}
