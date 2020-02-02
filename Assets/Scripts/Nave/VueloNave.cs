using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VueloNave : MonoBehaviour
{
    public float velocidad;
    public bool volando = false;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (volando)
        {
            transform.Translate((Vector3.up * velocidad)*Time.deltaTime);
        }
    }

/*
    void Update()
    {
        if (transform.position.y < 1800)
        {
            Time.timeScale = 50;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    */
        public void Despega()
    {
        volando = true;
        animator.enabled = false;
    }

    public void Aterriza()
    {
        volando = false;
        animator.SetBool("Aterriza", true);
        animator.enabled = true;
    }
}
