using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engranaje : MonoBehaviour
{
    float _realRotation;
    public float velocidad;
    public bool rotacionCorrecta = false;
    public Sprite encendido;
    public float rotacionFinal;

    void Start()
    {
        GirarPiezas();
    }

    void Update()
    {
        ComprobarRotacion();

        if (transform.root.eulerAngles.z!=_realRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _realRotation),velocidad);
        }     
    }

    private void OnMouseDown()
    {
        RotateGear();
    }

    private void RotateGear()
    {
        _realRotation += 45;
        if(_realRotation == 360)
        {
            _realRotation = 0;
        }
    }

    void GirarPiezas()
    {
            int rotaciones = Random.Range(0, 8);

            for (int i = 0; i < rotaciones; i++)
            {
                RotateGear();
            }
    }

    private void ComprobarRotacion()
    {
        if (_realRotation == rotacionFinal)
        {
            rotacionCorrecta = true;
            Debug.Log("Buena");
        }
    }
}
