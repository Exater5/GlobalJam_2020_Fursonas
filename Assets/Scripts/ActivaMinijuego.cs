using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaMinijuego : MonoBehaviour
{
    public GameObject[] minijuegos;
    public Transform spawnMJ;
    private void OnMouseDown()
    {
        print("HOLA");
        int randomJuego = Random.Range(2, 6);
        Instantiate(minijuegos[randomJuego], spawnMJ.position, Quaternion.identity);
        Camera.main.enabled = false;
        Destroy(gameObject);
    }
}
