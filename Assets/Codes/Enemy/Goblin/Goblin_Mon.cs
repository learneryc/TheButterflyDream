using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Mon : Goblin_Bass
{
    public float AtttackDis = 1f;
    public  AttackType GoblinType;
    // styneTime 
    private float TimeTic = 0;
    public float  StuneTime= 0.5f;
    public float  DieTime = 1f;
    public enum AttackType
    {
        Sword,
        Spear,
        Axe
    }
    // Start is called before the first frame update
     void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(Current_Tartget == null)
        {
            m_Anim.Play("Idle");
            return;
        }
        CheckPlayerApproaching();
    }   
     public override  void  TakeDamage(int damage) 
    {
        FlashColor(0.2f);
        m_HP -= damage;
        if(m_HP <=0)
        {
            m_StateAnim = StateAnim.Die;
            m_Anim.Play("Die");
            StartCoroutine(DieState());
            return;
        }
        m_StateAnim = StateAnim.Hitted;
    }

    
     IEnumerator DieState()
     {
         yield return new WaitForSeconds(DieTime);
         Destroy(gameObject);
     }
    //stateMachine 
    void CheckPlayerApproaching() 
    {
        float distance2Player = Vector2.Distance(Current_Tartget.transform.position, transform.position);
        MoveDir = Vector2.zero;
        switch (m_StateAnim)
        {
            case StateAnim.Idle:
            {
                if(distance2Player <= AtttackDis){
                    m_StateAnim = StateAnim.Attack;
                }else{
                    m_StateAnim = StateAnim.Run;
                }
                break;
            }
            case StateAnim.Run:
            {
                m_Anim.Play("Run");
                if(distance2Player <= AtttackDis){
                    m_StateAnim = StateAnim.Attack;
                }
                Move();
                break;
            }
            case StateAnim.Attack:
            {
                if(distance2Player >= AtttackDis){
                    m_StateAnim = StateAnim.Run;
                }
                switch(GoblinType)
                {
                    case AttackType.Axe:
                    {
                        m_Anim.Play("Attack_Axe");
                        break;
                    }
                    case AttackType.Sword:
                    {
                        m_Anim.Play("Attack_Sword");
                        break;
                    }
                    case AttackType.Spear:
                    {
                        m_Anim.Play("Attack_Spear");
                        break;
                    }
                }
                break;
            }
            case StateAnim.Hitted:
            {
                m_Anim.Play("Hit");
                TimeTic += Time.deltaTime;
                if (TimeTic > StuneTime)
                {
                    TimeTic = 0;
                    m_StateAnim = StateAnim.Idle;
                }
                break;
            }
            case StateAnim.Die:
            {
                // m_Anim.Play("Die");
                // TimeTic += Time.deltaTime;
                // if (TimeTic > DieTime)
                // {
                //     TimeTic = 0;
                //     Destroy(gameObject);
                // }
                 break;
            }
        }
    }
}
