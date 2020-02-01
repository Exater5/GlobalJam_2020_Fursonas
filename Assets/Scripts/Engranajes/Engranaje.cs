using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engranaje : MonoBehaviour
{
    float _realRotation;
    public float velocidad;
    bool _rotacionCorrecta = false;
    public Sprite encendido;
    public int rotacionFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.root.eulerAngles.z!=_realRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _realRotation),velocidad);
        }
        ComprobarRotacion();
    }

    private void OnMouseDown()
    {
        RotateGear();
    }

    public void RotateGear()
    {
        _realRotation += 45;
        if(_realRotation == 360)
        {
            _realRotation = 0;
        }
    }

    private void ComprobarRotacion()
    {
        if (transform.rotation.z == rotacionFinal)
        {
            _rotacionCorrecta = true;
            Debug.Log("Buena");
        }
    }
}
