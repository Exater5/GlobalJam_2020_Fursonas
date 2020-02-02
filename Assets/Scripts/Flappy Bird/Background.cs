using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Background : MonoBehaviour
{

    public float velocidad = 1f;
    Material miMaterial;

    void Start()
    {
        miMaterial = GetComponent<Renderer>().material;   
    }

    void Update()
    {
        miMaterial.mainTextureOffset = miMaterial.mainTextureOffset + Vector2.right * velocidad * Time.deltaTime;
    }

}
