using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The abstrect class of all enemies
public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        checkWithHealth();
    }

    private void checkWithHealth()
    {
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    // Player can use it to make damage to enemy
    // Usage: 1. Check OnTriggerEnter2D
    //        2. other.GetComponent<Enemy>().TakeDamage(damage);
    public void TakeDamage(int damage) 
    {
        health -= damage;
    }
}
