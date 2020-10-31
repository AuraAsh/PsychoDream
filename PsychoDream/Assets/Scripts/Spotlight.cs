using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    public GameObject Frank;

    void Update()
    {
        transform.LookAt(Frank.transform);
    }
}
