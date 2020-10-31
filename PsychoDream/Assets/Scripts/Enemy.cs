using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float visionRadius;
    public float speed;
    public Animator animEnemy;
    public AudioSource enemySound;
    public AudioClip[] clips;

    GameObject player;

    Vector3 initialPosition;

    void Awake()
    {
        animEnemy = GetComponent<Animator>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");


        initialPosition = transform.position;
    }

    void Update()
    {
        Vector3 target = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < visionRadius)
        {
            target = player.transform.position;
            animEnemy.SetBool("Crawl_fast", true);
        }
        if(dist <= 1)
        {
            enemySound.clip = clips[0];
            enemySound.Play();
            animEnemy.SetBool("Crawl_fast", false);
            animEnemy.SetBool("Pounce", true);
            StartCoroutine(DestructionEnemy());
        }
            
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.green);
    }

    IEnumerator DestructionEnemy()
    {
        yield return new WaitForSeconds(1.35f);
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
