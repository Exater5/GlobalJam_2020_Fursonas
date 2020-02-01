using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VueloNave : MonoBehaviour
{
    public float velocidad;
    public bool volando = false;
    private void FixedUpdate()
    {
        if (volando)
        {
            transform.Translate((Vector3.up * velocidad)*Time.deltaTime);
        }
    }
    public void Despega()
    {
        volando = true;
        GetComponent<Animator>().enabled = false;
    }
}
