using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator anim;
    public AudioSource boxSound;
    public GameObject boxContainer;
    public float wait_time = 2.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            boxSound.Play();
            anim.Play("box_open");
            StartCoroutine(Wait_for_message());
        }
    }

    IEnumerator Wait_for_message()
    {
        yield return new WaitForSeconds(wait_time);
        boxContainer.SetActive(true);
    }
}
