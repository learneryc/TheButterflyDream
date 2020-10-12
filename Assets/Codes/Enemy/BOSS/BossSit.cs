using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSit : StateMachineBehaviour
{
   ChantMagic magic;
   Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      animator.GetComponent<BossHealth>().isInvulnerable = false;
      magic = animator.GetComponent<ChantMagic>();
      boss = animator.GetComponent<Boss>();
      magic.Sit();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss.LookAtPlayer();
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.GetComponent<BossHealth>().isInvulnerable = true;
       animator.ResetTrigger("Chant");
    }


}
