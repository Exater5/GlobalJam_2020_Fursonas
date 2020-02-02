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
    float retraso;
    public Transform puntoASeguir;

    void Start()
    {
        retraso = 15;
        StartCoroutine(CreaRotura(retraso));
    }

    

    // Update is called once per frame
    void Update()
    {

    }

    //void randomSpark()
    //{
    //    GameObject instantiatedObject = Instantiate(sparkPoint[randomIndex], spark.transform.position, Quaternion.identity) as GameObject;
    //}

    IEnumerator CreaRotura(float retraso)
    {
        yield return new WaitForSeconds(retraso);
        sparkRange = UnityEngine.Random.Range(0,6);
        puntoASeguir = sparkPoint[sparkRange];
        Instantiate(spark);
        spark.GetComponent<Follow>().target = sparkPoint[sparkRange].gameObject;
        retraso = 30;
        StartCoroutine(CreaRotura(retraso));
    }

}
    


