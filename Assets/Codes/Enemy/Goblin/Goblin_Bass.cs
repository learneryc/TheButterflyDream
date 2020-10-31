using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Bass : MonoBehaviour
{
    // Start is called before the first frame update
    //
    protected Animator m_Anim;
    private BoxCollider2D m_touchSensor;
    private Rigidbody2D m_rig;
     protected Goblin_Weapon weapon;

    //
    public GameObject Current_Tartget;
    protected  bool bLeft = false;
    public float m_HP = 5;
    public float m_moveSpeed = 1;
    protected SpriteRenderer[] sr;
    protected Color[] originalColor;
    
    //
    public enum StateAnim
    {
        Idle,
        Run,
        Hitted,
        Die,
        Attack,
    }
    public StateAnim m_StateAnim = StateAnim.Idle;
    
    public void Start()
    {
        m_Anim =GetComponent<Animator>();
        m_touchSensor = GetComponent<BoxCollider2D>();
        m_rig = GetComponent<Rigidbody2D>();
        weapon = GetComponentsInChildren<Goblin_Weapon>()[0];
        sr = GetComponentsInChildren<SpriteRenderer>();
        originalColor = new Color[sr.Length];
        for(int i =0;i<sr.Length;i++)
        {
            originalColor[i] = sr[i].color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Filp()
    {
        if (Current_Tartget == null)
            return;

        float tmpValue = Current_Tartget.transform.position.x - this.transform.position.x;

        if (tmpValue > 0)
        {
            bLeft = false;
        }
        else
        {
            bLeft = true;
        }

        transform.localScale = new Vector3(bLeft ? 1 : -1, 1, 1);
    
    }
    protected Vector2 MoveDir;
    public void Move()
    {
        if (Current_Tartget == null)
            return;

        Filp();
        Vector2 tmpDir = Current_Tartget.transform.position - this.transform.position;
        tmpDir = new Vector2(tmpDir.x, 0);

        MoveDir = tmpDir.normalized * 1 * m_moveSpeed;
        transform.transform.Translate(tmpDir.normalized * 1 * m_moveSpeed * Time.deltaTime);

    }

    void OnTriggerStay2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
        {
            Current_Tartget = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
        {
            Current_Tartget = null;
        }
    }
    // be hit
     public virtual void TakeDamage(int damage) 
    {
        FlashColor(0.2f);
        m_HP -= damage;
    }

    public void FlashColor(float time)
    {
        for(int i =0 ; i< sr.Length ;i++)
        {
            sr[i].color = Color.red;
        }
        Invoke("ResetColor",time);
    }

    public void ResetColor()
    {
       for(int i =0 ; i< sr.Length ;i++)
        {
            sr[i].color = originalColor[i];
        }
    }

    // attack 
    public void StartAttack(){
        weapon.Attack();
    }
    public void AfterAttack(){
        weapon.AfterAttack();
    }

}
