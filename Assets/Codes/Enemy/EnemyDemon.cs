using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemon : Enemy
{

    private BoxCollider2D attackArea;
    private bool playerApproaching;
    private Transform Player;
    
    public float runrang;
    public float attackrang;
    public float runspeed;
    public bool attackAllowed ;
    private Vector2 originalPos;
    private Vector2 targetPos;
    private bool isleft;

    public enum EnemyState
    {
        idle,
        run,
        attack
    }
    public EnemyState CurrentState = EnemyState.idle;
    // Start is called before the first frame update
    public void Start()
    {
    	base.Start();
        attackArea = GetComponent<BoxCollider2D>();
       
        Player = GameObject.FindWithTag("Player").transform;
        attackAllowed = true;
        originalPos = transform.position;
        targetPos = originalPos;
        isleft = true;
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        CheckPlayerApproaching();
        // AI attack 
        
    }

  

    void CheckPlayerApproaching() 
    {
        float distance2Player = Vector2.Distance(Player.position, transform.position);
        float distance2Ori = Vector2.Distance(originalPos, transform.position);
        if(isleft){
            if(targetPos.x > transform.position.x){
                transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 0);
                isleft = false;
            }
        }else{
            if(targetPos.x < transform.position.x){
                transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 0);
                isleft = true;
            }
        }
        //Debug.Log(CurrentState);
        switch (CurrentState)
        {
            case EnemyState.idle:

                if(distance2Ori >2f)
                {
                    targetPos = originalPos;
                    CurrentState = EnemyState.run;
                    
                }
                if(distance2Player > attackrang && distance2Player <= runrang)  
                {
                    targetPos = Player.position;
                    CurrentState = EnemyState.run;
                }
                if (distance2Player < attackrang )
                {
                    CurrentState = EnemyState.attack;
                }
                attackArea.enabled = false;
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", false);
                break;
            case EnemyState.run:
                if (distance2Player > runrang )
                {
                    CurrentState = EnemyState.run;
                    targetPos = originalPos;
                }
                if(distance2Player > attackrang && distance2Player <= runrang)  
                {
                    targetPos = Player.position;
                }
                if (distance2Player < attackrang )
                {
                    CurrentState = EnemyState.attack;
                }
                if(distance2Ori < 2f  && distance2Player > runrang)
                {
                    CurrentState = EnemyState.idle;
                }

                transform.position = transform.position - new Vector3((transform.position.x - targetPos.x) * runspeed * Time.deltaTime,0,0);                
                
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", true);
                attackArea.enabled = false;
                break;
            case EnemyState.attack:
                if(distance2Player > attackrang && distance2Player <=runrang)
                {
                    CurrentState = EnemyState.run;
                    targetPos = Player.position;
                }
                if (distance2Player > runrang)
                {
                    CurrentState = EnemyState.idle;
                }
                if(distance2Player > attackrang* 0.8f)
                {
                    transform.position = transform.position - new Vector3((transform.position.x - Player.position.x) * runspeed * Time.deltaTime,0,0);
                }
                targetPos = Player.position;
                if(attackAllowed)
                {
                    if(!animator.GetBool("Dead"))
                    {
                        StartCoroutine(EnemyAttacking());
                        attackAllowed = false;
                    }
                    
                }
                break;

        }
    }
    IEnumerator EnemyAttacking(){
        animator.SetBool("Attack", true);
        animator.SetBool("Walk", false);
        yield return new WaitForSeconds(0.5f);
        attackArea.enabled = true;
        yield return new WaitForSeconds(0.8f);
        attackArea.enabled = false;
        CurrentState = EnemyState.idle;
        yield return new WaitForSeconds(1f);
        attackAllowed = true;
    }


}
