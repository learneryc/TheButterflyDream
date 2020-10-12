using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnragedRun : StateMachineBehaviour
{
    public float speed = 3f;
    private Transform targetPos ; 
    Rigidbody2D rb;
    Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        targetPos = GameObject.Find("BossPos").transform;
        boss = animator.GetComponent<Boss>();
        animator.GetComponent<CapsuleCollider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPos();
       Vector2 target = new Vector2(targetPos.position.x , rb.position.y);
       Vector2 newPos = Vector2.MoveTowards(rb.position,target,speed * Time.fixedDeltaTime);
       rb.MovePosition(newPos);
       if(Vector2.Distance(targetPos.position, rb.position ) <= 0.5f )
       {
          animator.SetTrigger("Chant");
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CapsuleCollider2D>().enabled = true;
       rb.bodyType = RigidbodyType2D.Dynamic;
    }


}
