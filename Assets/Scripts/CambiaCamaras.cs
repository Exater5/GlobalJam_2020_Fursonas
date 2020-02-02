using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCamaras : MonoBehaviour
{
    Camera cPrincipal;
    Camera cMinijuego;
    // Start is called before the first frame update
    void Start()
    {
        cPrincipal = Camera.main;
    }

    public void CambiaCamara()
    {
        cPrincipal.enabled = false;
    }
    public void ReactivaPrincipal()
    {
        cPrincipal.enabled = true;
    }
}
