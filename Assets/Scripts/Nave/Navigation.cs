using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    [SerializeField]
    public List<Vector3> navPoints;

    public void Awake()
    {
        navPoints = new List<Vector3>();
        for (int i = 0; i < transform.childCount; i++)
        {
            navPoints.Add(transform.GetChild(i).position);
        }
    }
}
