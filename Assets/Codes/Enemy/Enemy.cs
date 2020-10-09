using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The abstrect class of all enemies
public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    protected Animator animator;
    protected SpriteRenderer sr;
    public Color originalColor;
    private Swordman jack;
    private BoxCollider2D attackrange;


    // Start is called before the first frame update
    public void Start()
    {
        jack = GameObject.FindGameObjectWithTag("Player").GetComponent<Swordman>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        attackrange = GetComponent<BoxCollider2D>();
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
            attackrange.enabled = false;
            animator.SetBool("Dead", true);
            Destroy(gameObject, 0.5f);
        }
    }

    // Player can use it to make damage to enemy
    // Usage: 1. Check OnTriggerEnter2D
    //        2. other.GetComponent<Enemy>().TakeDamage(damage);
    public void TakeDamage(int damage) 
    {
        FlashColor(0.2f);
        health -= damage;
        //animator.Play("hurt");
    }

    public void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor",time);
    }

    public void ResetColor()
    {
        sr.color = originalColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if(jack != null)
            {
                jack.beAttacked(damage);
            }
        }
    }
}
