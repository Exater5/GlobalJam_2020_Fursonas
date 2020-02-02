using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
