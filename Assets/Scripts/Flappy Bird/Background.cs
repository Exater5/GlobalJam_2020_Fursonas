using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Background : MonoBehaviour
{
    public float velocidad = 1f;
    SpriteRenderer _sp;

    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();   
    }

    void Update()
    {
        _sp.size += (Vector2.right * velocidad * Time.deltaTime);
    }
}