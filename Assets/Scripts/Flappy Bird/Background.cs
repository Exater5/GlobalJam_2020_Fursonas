using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Background : MonoBehaviour
{

    public float velocidad = 1f;
    Material miMaterial;
    //Animator myAnim;

    // Use this for initialization
    void Start()
    {
        miMaterial = GetComponent<Renderer>().material;
        //myAnim = GetComponent<Animator>();
        //Player.onTerremotoReached += AplicarTerremoto;
    }

    // Update is called once per frame
    void Update()
    {
        miMaterial.mainTextureOffset = miMaterial.mainTextureOffset + Vector2.right * velocidad * Time.deltaTime;
    }

    //void AplicarTerremoto()
    //{
        //myAnim.enabled = true;
        //velocidad = velocidad * 2;
    //}
}
