using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActivaMinijuego : MonoBehaviour
{
    public Scene[] minijuegos;

    private void OnMouseDown()
    {
        int randomScene = Random.Range(2, 6);
        SceneManager.MergeScenes(minijuegos[randomScene], SceneManager.GetActiveScene());
        Destroy(gameObject);
    }
}
