using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;


public class HealthBar : MonoBehaviour
{
    [SerializeField] internal float healthPlayer;
    public float velocity_time = 0.30f;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject menuContainer;
    public AudioSource deathSound;
    public AudioSource healthSound;
    public AudioClip[] clips;
    private Animator anim;


    private void Start()
    {
        healthPlayer = slider.value;
        fill.color = gradient.Evaluate(1f);
        anim = GetComponent<Animator>();
    }

    public void ReduceHealth() //Verifica si la salud del jugador se reduce, se llama en el script "Damage"
    {
        slider.value -= 1;
        anim.Play("Damage");
        StartCoroutine(LessVelocity());
        healthPlayer = slider.value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        healthSound.clip = clips[0];
        healthSound.Play();
    }
    public void VerifyHealth() //Verifica salud actual
    {
        if(healthPlayer <= 0)
        {
            Destroy(gameObject);
            deathSound.Play();
            menuContainer.SetActive(true);
            Analytics.CustomEvent("Game Over");
        }
    }

    IEnumerator LessVelocity() //Cuando recibe daño, su velocidad es menor
    {
        
        var actualVelocity = GetComponent<Logic>().movementVelocity;
        GetComponent<Logic>().movementVelocity = 0;
        yield return new WaitForSeconds(velocity_time);
        GetComponent<Logic>().movementVelocity = actualVelocity;
        
    }
}
