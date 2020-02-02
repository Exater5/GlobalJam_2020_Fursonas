using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlLuces : MonoBehaviour
{
    public static int puntos = 0;
    public int puntosMax = 2;
    public static int fallos = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fallos <= 0)
        {
            FindObjectOfType<ThirdPersonCamera>().GetComponent<Camera>().enabled = true;
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(GameController.escenaActual), UnloadSceneOptions.None);
            //Destruyenave
        }

        if (puntos >= puntosMax)
        {
            FindObjectOfType<ThirdPersonCamera>().GetComponent<Camera>().enabled = true;
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(GameController.escenaActual), UnloadSceneOptions.None);
        }
    }
}
