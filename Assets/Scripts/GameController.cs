﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    bool pausado = false;
    public Animator animMenuIngame;
    public Image botonPausa;
    public Sprite[] pausa;
    public static string escenaActual;
    public void Pausa()
    {
        if (!pausado)
        {
            Time.timeScale = 0f;
            animMenuIngame.SetTrigger("Entra");
            pausado = true;
            botonPausa.sprite = pausa[1];
        }
        else
        {
            Time.timeScale = 1;
            animMenuIngame.SetTrigger("Sale");
            pausado = false;
            botonPausa.sprite = pausa[0];
        }
    }
    public void Reinicia()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Scene");
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Activa()
    {
        StartCoroutine(Destruye());
    }
    public IEnumerator Destruye()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
