using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Heal : Goblin_Bass
{
    //public  CircleCollider2D m_touchSensor;
    public int m_damage =1; 
    private float TimeTic = 0;
    public float  StuneTime= 0.2f;
    public float  DieTime = 0.5f;
    public bool AttackAllow = true;
    public float AttackCD = 1f;
    public float AtttackDis = 2f;
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
            return;
        }
        CheckPlayerApproaching();
    }

    public GameObject FireBottle;
    public Transform RotateSocket;
    public GameObject WeaponSocket;
    protected void CreatePotion()
    {

            GameObject tmpobj = Instantiate(FireBottle, WeaponSocket.transform.position, WeaponSocket.transform.localRotation);

            if (bLeft)
            {
                tmpobj.transform.right = -RotateSocket.transform.right;
            }
            else
            {
                tmpobj.transform.right = RotateSocket.transform.right;
            }



            Vector3 pos1 = Current_Tartget.transform.position - this.transform.position;
       
            float tmpangle = Vector3.Angle(this.transform.up, pos1);

           
            tmpobj.GetComponent<HealBossScript>().Fire(Current_Tartget.transform.position,tmpangle,m_damage);
        

        // tmpobj.transform.right = dir;

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


    
    void AttackCoolDown(){
         AttackAllow = true;
     }

    public bool b_DefaultAttack_Anim = false;

    public  void DefaultAttack_Anim_1_Enter()
    {
        // Is_OnceAttack = true;

      //Debug.Log("Attack1공격");
        b_DefaultAttack_Anim = true;
        CreatePotion();
        RotateSocketFuc(RotateSocket.transform.position, Current_Tartget.transform.position, 45);
    }
    public void RotateSocketFuc(Vector3 currentPos, Vector3 targetPos, float initialAngle)
    {
        if (RotateSocket == null)
            return;

        Vector3 v = targetPos - currentPos;

        float Angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;




        if (float.IsNaN(Angle))
        {

        }
        else
        {


            if (bLeft)
            {
                RotateSocket.transform.localRotation = Quaternion.AngleAxis(Angle - 180, Vector3.forward);
            }
            else
            {
                RotateSocket.transform.localRotation = Quaternion.AngleAxis(-Angle, Vector3.forward);
            }



        }


    }
    public  void DefaultAttack_Anim_1_Exit()
    {
        b_DefaultAttack_Anim = false;
    }

    // State Machine
    void CheckPlayerApproaching() 
    {   
        if(Current_Tartget == null)
        {
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
                m_Anim.Play("Attack_FireBottle");
                if (!b_DefaultAttack_Anim)
                {
                Filp();
                }
                DefaultAttack_Anim_1_Enter();
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
                 break;
            }
        }
    }
}
