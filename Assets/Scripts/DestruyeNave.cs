using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestruyeNave : MonoBehaviour
{
    public int vidas = 2;
    public GameObject particulasExplosion;

    public void QuitaVidas()
    {
        --vidas;
        if(vidas <= 0)
        {
            Explota();
        }
    }
    public void Explota()
    {
        SceneManager.LoadScene("Escena Final Mal");
    }
    public void Aterriza()
    {
        SceneManager.LoadScene("Escena Final Bien");
    }
}
