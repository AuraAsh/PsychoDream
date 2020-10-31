using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject camContainer;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            camContainer.SetActive(true);
        }
    }
}
