using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Puntos : MonoBehaviour
{
    Puzzle3_GameManager _gm;

    public int dificultad;
    float tiempoTotal;
    float tiempoActual;

    void Start()
    {
        _gm = GetComponent<Puzzle3_GameManager>();

        switch (dificultad)
        {
            case 1:
                tiempoTotal = 15f;
                break;
            case 2:
                tiempoTotal = 12f;
                break;
            case 3:
                tiempoTotal = 8f;
                break;
            case 4:
                tiempoTotal = 5f;
                break;
            default:
                tiempoTotal = 15f;
                break;
        }

        tiempoTotal += Time.time;
    }
    
    void Update()
    {
        tiempoActual = Time.time;

        if (tiempoActual >= tiempoTotal && !_gm.victoria)
        {
            Debug.Log("Has Perdido");
        }
    }
}