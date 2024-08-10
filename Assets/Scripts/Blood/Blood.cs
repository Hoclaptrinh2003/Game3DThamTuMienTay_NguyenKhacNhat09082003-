using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public int health = 10; // Máu của đối tượng


    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Current Health: " + health); 

        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        Debug.Log(gameObject.name + " has died."); 
        animator.SetBool("isDie",true);
        Destroy(gameObject,3); 
    }
}
