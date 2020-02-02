using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActivaMinijuego : MonoBehaviour
{
    public string[] minijuegos;
    public Transform spawnMJ;
    Camera camaraMain;
    private void Start()
    {
        camaraMain = Camera.main;
        minijuegos = new string[] { "Engranajes", "Flappy bird", "Puzzle 3 - Tuberías_Sergio", "Puzzle Luces" };
    }
    private void OnMouseDown()
    {
        int randomJuego = Random.Range(0, minijuegos.Length);
        SceneManager.LoadSceneAsync(minijuegos[randomJuego],LoadSceneMode.Additive);

        camaraMain.enabled = false;
        Destroy(gameObject);
    }
}
