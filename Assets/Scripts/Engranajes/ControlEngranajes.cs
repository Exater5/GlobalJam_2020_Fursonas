using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEngranajes : MonoBehaviour
{
    int cantidadEngranajes;
    Engranaje[] engranajes;
    List<GameObject> gOEngranajes = new List<GameObject>();
    public Sprite[] encendido;
    public bool win = false;
    public Sprite numEncendido;
    public GameObject pantallaTeclado;
    void Start()
    {
        engranajes = FindObjectsOfType<Engranaje>();
        cantidadEngranajes = engranajes.Length;
        for (int i = 0; i < cantidadEngranajes; i++)
        {
            gOEngranajes.Add(engranajes[i].gameObject);
        }
    }


    void Update()
    {
        CheckWin();
    }

    private void CheckWin()
    {
        for (int i = 0; i < cantidadEngranajes; i++)
        {
            if (gOEngranajes[i].GetComponent<Engranaje>().rotacionCorrecta == false)
            {
                win = false;
                break;
            }
            win = true;
            pantallaTeclado.GetComponent<SpriteRenderer>().sprite = numEncendido;
            for (int j = 0; j < cantidadEngranajes; j++)
            {
                gOEngranajes[j].GetComponent<SpriteRenderer>().sprite = encendido[j];
            }
        }
    }
}

