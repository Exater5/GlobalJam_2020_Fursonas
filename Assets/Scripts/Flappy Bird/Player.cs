using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float jumpForce = 3.0f;
    public static int puntos = 0;
    Rigidbody2D miRigidboby;
    //public Text textoPuntos;
    //public GameObject gameOver;
    //AudioSource emisorAudio;
    //public AudioClip sonidoSalto;
    //public AudioClip sonidoMoneda;
    //public AudioClip sonidoMuerte;
    //public static Action onTerremotoReached;


    void Start()
    {
        miRigidboby = GetComponent<Rigidbody2D>();
        //emisorAudio = GetComponent<AudioSource>();
        //onTerremotoReached = null;
        puntos = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touches.Length == 1 && Input.touches[0].phase == TouchPhase.Began)
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

        //if (puntos == 20)
        //{
          //  onTerremotoReached.Invoke();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if (puntos > PlayerPrefs.GetInt("highscore"))
        //{
        //PlayerPrefs.SetInt("highscore", puntos);
        //}

        //emisorAudio.PlayOneShot(sonidoMuerte);
        Destroy(gameObject);
        //gameOver.SetActive(true);
    }
}
