using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float tiempoEntreSpawns = 1.0f;
    public GameObject prefabObstaculo;
    public float rangoAleatorio;


    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, tiempoEntreSpawns);
        //Player.onTerremotoReached += AplicarTerremoto;
    }

    void Spawn()
    {
        float Diferencia = Random.Range(-rangoAleatorio, rangoAleatorio);
        Instantiate(prefabObstaculo, transform.position + Diferencia * Vector3.up, Quaternion.identity);
    }

    //void AplicarTerremoto()
    //{
        //CancelInvoke("Spawn");
        //InvokeRepeating("Spawn", 0.0f, tiempoEntreSpawns * 0.6f);
    //}
}
