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
            StartCoroutine(Explota());
        }
    }
    IEnumerator Explota()
    {
        Instantiate(particulasExplosion, transform.position, Quaternion.identity);
        FindObjectOfType<GameController>().GetComponent<GameController>().Activa();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
