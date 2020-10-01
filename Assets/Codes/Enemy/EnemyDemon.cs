using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemon : Enemy
{

    private BoxCollider2D attackArea;
    private bool playerApproaching;


    // Start is called before the first frame update
    public void Start()
    {
    	base.Start();
        //base.Update();
        attackArea = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        CheckPlayerApproaching();
    }

    void CheckPlayerApproaching() 
    {
        playerApproaching = attackArea.IsTouchingLayers(LayerMask.GetMask("Player"));
        if (playerApproaching) 
        {
            animator.SetBool("Attack", true);
        }
        else 
        {
            animator.SetBool("Attack", false);
            //Debug.Log(base.health);
        }
    }

    // public void OnTriggerEnter2D(Collider2D other){
    //     if(other.gameObject.CompareTag("Player")){
    //         //other.GetComponent<Enemy>().TakeDamage(damage);
    //         Swordman.beAttacked();
    //     }
    // }
}
