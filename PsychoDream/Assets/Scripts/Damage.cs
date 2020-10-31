using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public AudioSource hurtSound;
    public AudioClip[] clips;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) //Si el jugador entra en la zona enemiga 
        {
           other.GetComponent<HealthBar>().ReduceHealth(); //Verificacion cuando el jugador colisiona
            hurtSound.clip = clips[0];
            hurtSound.Play();
        }
    }
}
