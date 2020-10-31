using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifenDamage : MonoBehaviour
{
    public int life = 3; //Vida del jugador 
    public int currentLife;
    public HealthBar healthBar;
    public AudioSource lifeSound;
    

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }

    void Start()
    {
        currentLife = life;
        //healthBar.SetMaxHealth(life);

        InvokeRepeating("Lesslife",0.1f,1f);
    }

    public void Lesslife() //Funcion restar cantidad especifica de vida
    {
        healthBar.VerifyHealth(); //Llamo funcion verificar salud
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Medicine")) //Objetos que suman vida que perdio al jugador
        {
            if(healthBar.healthPlayer < 3)
            {
                lifeSound.Play();
                healthBar.slider.value += 1;
                healthBar.healthPlayer = healthBar.slider.value;
                Destroy(other.gameObject);
            }
        }
    }

        
    
}
