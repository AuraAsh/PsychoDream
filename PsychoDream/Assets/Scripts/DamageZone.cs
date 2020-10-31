using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public AudioSource damageSound;
    public AudioSource hurtSound;
    public AudioClip[] clips;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Si el jugador entra en la zona enemiga 
        {
            other.GetComponent<HealthBar>().ReduceHealth(); //Verificacion cuando el jugador colisiona
            damageSound.clip = clips[Random.Range(0, clips.Length)];
            damageSound.Play();
            hurtSound.Play();
        }
    }
}
