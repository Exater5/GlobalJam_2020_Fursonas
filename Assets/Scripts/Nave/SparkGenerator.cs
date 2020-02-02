using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkGenerator : MonoBehaviour
{
    public Transform[] sparkPoint;
    public GameObject spark;
    int randomIndex;
    int sparkRange = 0;
    int tiempoEspera;
    float retraso;


    void Start()
    {
        retraso = 4;
        randomIndex = UnityEngine.Random.Range(0, 6);
        StartCoroutine(CambiarEstados(retraso));
    }

    

    // Update is called once per frame
    void Update()
    {

    }

    //void randomSpark()
    //{
    //    GameObject instantiatedObject = Instantiate(sparkPoint[randomIndex], spark.transform.position, Quaternion.identity) as GameObject;
    //}

    IEnumerator CambiarEstados(float retraso)
    {
        yield return new WaitForSeconds(retraso);
        sparkRange =randomIndex;
        spark = Instantiate(spark, sparkPoint[sparkRange].position, Quaternion.identity);
        spark.transform.SetParent(sparkPoint[sparkRange]);
        tiempoEspera = 2;
        StartCoroutine(CambiarEstados(retraso));
    }

}
    


