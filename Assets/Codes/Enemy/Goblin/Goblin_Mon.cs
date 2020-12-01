using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Mon : Goblin_Bass
{
    public float AtttackDis = 1f;
    public  AttackType GoblinType;
    // stuneTime 
    private float TimeTic = 0;
    public float  StuneTime= 0.5f;
    public float  DieTime = 1f;
    public bool AttackAllow = true;
    public float AttackCD = 1f;
    protected Goblin_Weapon weapon;
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
        weapon = GetComponentsInChildren<Goblin_Weapon>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Current_Tartget == null)
        {
            
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
            // m_StateAnim = StateAnim.Die;
            //m_Anim.Play("Die");
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

     void AttackCoolDown(){
         AttackAllow = true;
     }


     // attack 
    public void StartAttack(){
        weapon.Attack();
    }
    public void AfterAttack(){
        weapon.AfterAttack();
    }

    //stateMachine 
    void CheckPlayerApproaching() 
    {   
        if(Current_Tartget == null){
                    m_Anim.Play("Idle");
                    return;
                }
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
                if(!AttackAllow) return;
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
                AttackAllow = false;
                 Invoke("AttackCoolDown",AttackCD);
                break;
            }
            case StateAnim.Hitted:
            {
                
                TimeTic += Time.deltaTime;
                if (TimeTic > StuneTime)
                {
                    TimeTic = 0;
                    m_StateAnim = StateAnim.Idle;
                }
                if(m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")){
                    return;
                }
                m_Anim.Play("Hit");
                break;
            }
            case StateAnim.Die:
            {
                TimeTic += Time.deltaTime;
                if (TimeTic > DieTime)
                {
                    TimeTic = 0;
                    Destroy(gameObject);
                }
                if(m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Die")){
                    return;
                }
                m_Anim.Play("Die");
                StartCoroutine(DieState());
                
                 break;
            }
        }
    }
}
