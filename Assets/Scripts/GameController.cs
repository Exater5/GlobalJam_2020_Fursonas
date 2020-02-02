using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    bool pausado = false;
    public Animator animMenuIngame;
    public void Pausa()
    {
        if (!pausado)
        {
            Time.timeScale = 0f;
            animMenuIngame.SetTrigger("Entra");
            pausado = true;
        }
        else
        {
            Time.timeScale = 1;
            animMenuIngame.SetTrigger("Sale");
            pausado = false;
        }
    }
    public void Reinicia()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuPrincipal()
    {

    }
}
