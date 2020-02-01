using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject Earth;
    [SerializeField] private GameObject Moon;
    [SerializeField] private bool reverseMove = false;
    [SerializeField] private Transform objectToUse;
    
    private float startTime;
    private float Length;
    private float distCovered;
    private float fracJourney;
    void Start()
    {
        startTime = Time.time;
        
        Length = Vector3.Distance(Earth.transform.position, Moon.transform.position);
    }
    void Update()
    {
        distCovered = (Time.time - startTime) * moveSpeed;
        fracJourney = distCovered / Length;
        if (reverseMove)
        {
            objectToUse.position = Vector3.Lerp(Moon.transform.position, Earth.transform.position, fracJourney);
        }
        else
        {
            objectToUse.position = Vector3.Lerp(Earth.transform.position, Moon.transform.position, fracJourney);
        }
        if ((Vector3.Distance(objectToUse.position, Moon.transform.position) == 0.0f || Vector3.Distance(objectToUse.position, Earth.transform.position) == 0.0f))
        {
            if (reverseMove)
            {
                reverseMove = false;
            }
            else
            {
                reverseMove = false;
            }
            startTime = Time.time;
        }
        if ( objectToUse.position == Moon.transform.position)
        {
            Destroy(objectToUse);
        }

    }

}







