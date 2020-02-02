using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Pieza : MonoBehaviour
{
    Puzzle3_GameManager _gm;

    public Sprite piezaOriginal;
    public Sprite piezaSeleccionada;

    public int[] valores;

    float rotacionReal;
    float velocidad = 0.3f;

    public bool _esInicio = false;
    public bool _estaActiva = false;
    
    [SerializeField]
    Vector2 index;
    
    public void SetIndex(Vector2 ind)
    {
        index = ind;
    }

    void Start()
    {
        _gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<Puzzle3_GameManager>();
    }

    void Update()
    {
        if (transform.root.eulerAngles.z != rotacionReal)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rotacionReal), velocidad);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<Puzzle3_GameManager>().ElegirPieza(index);        
    }

    public void RotarPieza()
    {
        if (!_esInicio)
        {
            rotacionReal += 90;

            if (rotacionReal == 360)
                rotacionReal = 0;

            RotarValores();
        }
    }

    public void RotarValores()
    {
        int aux = valores[0];

        for (int i = 0; i < valores.Length - 1; i++)
            valores[i] = valores[i + 1];

        valores[3] = aux;
    }
}