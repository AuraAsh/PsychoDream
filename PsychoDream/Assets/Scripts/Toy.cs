using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    public GameObject toyContainer;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            toyContainer.SetActive(true);
        }
    }
}
