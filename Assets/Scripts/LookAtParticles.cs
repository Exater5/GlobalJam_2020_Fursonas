using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtParticles : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
