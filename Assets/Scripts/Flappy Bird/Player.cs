using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float jumpForce;
    public static int puntos = 0;
    Rigidbody2D miRigidboby;
    //public Text textoPuntos;
    //public GameObject gameOver;
    //AudioSource emisorAudio;

    void Start()
    {
        miRigidboby = GetComponent<Rigidbody2D>();
        //emisorAudio = GetComponent<AudioSource>();
        //onTerremotoReached = null;
        puntos = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            miRigidboby.velocity = Vector2.up * jumpForce;
            //emisorAudio.PlayOneShot(sonidoSalto);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puntos++;
        //textoPuntos.text = "Score: " + puntos.ToString();
        //emisorAudio.PlayOneShot(sonidoMoneda);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //emisorAudio.PlayOneShot(sonidoMuerte);
        Destroy(gameObject);
        //gameOver.SetActive(true);
    }
}