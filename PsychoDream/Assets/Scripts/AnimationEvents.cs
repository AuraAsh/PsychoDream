using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource footSound;

    public void Footstep(float walkSpeed)
    {
        footSound.clip = clips[0];
        footSound.Play();
    }
}
