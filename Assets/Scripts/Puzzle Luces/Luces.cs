using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luces : MonoBehaviour
{
    int estadoLuz = 0;
    float retraso;
    GameObject guardaColores;

    void Start()
    {
        retraso = Random.Range(1, 4);
        StartCoroutine(CambiarEstados(retraso));
        guardaColores = FindObjectOfType<GuardaSprites>().gameObject;
    }


    IEnumerator CambiarEstados(float retraso)
    {
        yield return new WaitForSeconds(retraso);
        estadoLuz = Random.Range(0, 3);
        switch (estadoLuz)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = guardaColores.GetComponent<GuardaSprites>().colores[0];
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = guardaColores.GetComponent<GuardaSprites>().colores[1];
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = guardaColores.GetComponent<GuardaSprites>().colores[2];
                break;
        }
        retraso = Random.Range(1, 4);
        StartCoroutine(CambiarEstados(retraso));
    }
    private void OnMouseDown()
    {
        if (estadoLuz == 1)
        {
            ControlLuces.puntos++;
            estadoLuz = 0;
            GetComponent<SpriteRenderer>().sprite = guardaColores.GetComponent<GuardaSprites>().colores[0];
        }

        if (estadoLuz == 2)
        {
            ControlLuces.fallos--;
            estadoLuz = 0;
            GetComponent<SpriteRenderer>().sprite = guardaColores.GetComponent<GuardaSprites>().colores[0];
        }
    }
}