using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveMinigames : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadA()
    {
        print("alala");
        //SceneManager.LoadScene("Flappy bird", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Flappy bird", LoadSceneMode.Additive);
    }

    void Image()
    {
        canvas.SetActive(true);
    }

}
