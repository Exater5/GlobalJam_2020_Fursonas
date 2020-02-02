using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActivaMinijuego : MonoBehaviour
{
    public string[] minijuegos;
    public Transform spawnMJ;
    private void Start()
    {
        minijuegos = new string[] { "Flappy bird", "Puzzle 3 - Tuberías_Sergio", "Puzzle Luces" };
    }
    private void OnMouseDown()
    {
        int randomJuego = Random.Range(0, minijuegos.Length);
        SceneManager.LoadSceneAsync(minijuegos[randomJuego],LoadSceneMode.Additive);
        GameController.escenaActual = minijuegos[randomJuego];
        Camera.main.enabled = false;
        Destroy(gameObject);
    }
}
