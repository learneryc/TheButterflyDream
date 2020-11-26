using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Swordman : PlayerController
{
    private string scene="GameOver";
	public Animator transition;
	public string trigger = "CrossFade";
	public float transitionTime = 1f;
    public Renderer[] myRenderer;
    public bool isInvulnerable = false;
    public bool healthReduceOne = false;
    public Joystick joystick;
    public int dropDownPosition = -20;

    private void Start()
    {
        myRenderer = GetComponentsInChildren<Renderer>();
        m_CapsulleCollider  = this.transform.GetComponent<CapsuleCollider2D>();
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();

        if (joystick == null)
            joystick = GameObject.Find("Fixed Joystick")
                        .GetComponent<FixedJoystick>();
    }



    private void Update()
    {
        checkAlive();

        checkInput();


        if (checkDropDown() && !isDroppedDown) {
            if (!healthReduceOne) {
                curHealth -= 2;
                healthReduceOne = true;
            }
            isDroppedDown = true;
            if(curHealth <= 0) {
                //GameObject.Find("LevelLoader").
                //GetComponent<LevelLoader>().MoveToNextLevel(scene);
            }
            else{
//                System.Threading.Thread.Sleep(600);
                Vector3 pos = m_rigidbody.position;
                pos.x = -6;
                pos.y = 4;
                m_rigidbody.position = pos;
            }
            
        }
        if (isGrounded) {
            healthReduceOne = false;
        }
        if (m_rigidbody.position.y > 3) {
            isDroppedDown = false;
        }

        if (m_rigidbody.velocity.magnitude > 30)
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x - 0.1f, m_rigidbody.velocity.y - 0.1f);

        }

    }

    public void checkInput()
    {



        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            IsSit = true;
            m_Anim.Play("Sit");


        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {

            m_Anim.Play("Idle");
            IsSit = false;

        }


        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Sit") || m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentJumpCount < JumpCount)  // 0 , 1
                {
                    DownJump();
                }
            }

            return;
        }


        m_MoveX = Input.GetAxis("Horizontal");
        m_MoveX = m_MoveX!=0? m_MoveX:joystick.Horizontal;


   
        GroundCheckUpdate();


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Q))
            {
                attack();
            }
            else
            {

                if (m_MoveX == 0)
                {
                    if (!OnceJumpRayCheck)
                        m_Anim.Play("Idle");

                }
                else
                {

                    m_Anim.Play("Run");
                }

            }
        }


        if (Input.GetKey(KeyCode.Alpha1))
        {
            m_Anim.Play("Die");

        }

        if (Input.GetKey(KeyCode.RightArrow)||joystick.Horizontal >= .2f)
        {

            if (isGrounded)
            {

                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);

            }
            else
            {

                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }

            //if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                //return;

            if (!m_FacingRight)
            {
                Flip();
                //Flip(false);
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow)||joystick.Horizontal <= -.2f)
        {

            if (isGrounded)
            {
//                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
//                    return;

                transform.transform.Translate(Vector2.left * m_MoveX * MoveSpeed * Time.deltaTime);

            }
            else
            {

                transform.transform.Translate(new Vector3(-m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }

            //if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                //return;

            // if (!Input.GetKey(KeyCode.RightArrow))
            //     Flip(true);
            if (m_FacingRight)
            {
                Flip();
                //Flip(false);
            }


        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }

    public void attack() {
        Vector3 mousePosition = Input.mousePosition;
        float mPosX = mousePosition.x;
        float mPosY = mousePosition.y;
        m_Anim.Play("Attack");
        AudioManager.instance.Play("Sound/attackWithoutHitting", 1.0);
    }

    public void jump() {
        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return;

        if (currentJumpCount < JumpCount)  // 0 , 1
        {
            if (!IsSit)
            {
                prefromJump();

            }
            else
            {
                DownJump();

            }


        }
    }

    protected override void LandingEvent()
    {


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            m_Anim.Play("Idle");

    }

    public void beAttacked(int damage) 
    {
        if(isInvulnerable)return;
        curHealth-= damage;
        isInvulnerable = true;
        StartCoroutine(CancleInvulnerable());
        checkAlive();
        BlinkPlayer();
    }
    IEnumerator CancleInvulnerable()
    {
        yield return new WaitForSeconds(0.5f);
        isInvulnerable = false;
    }

    public bool checkDropDown() {
        if (m_rigidbody.position.y < dropDownPosition) {
            return true;
        } else {
            return false;
        }
    }

    private void checkAlive() {
        if(curHealth <= 0)
            GameObject.Find("LevelLoader").
                GetComponent<LevelLoader>().MoveToNextLevel(scene);
    }
    
    public void BlinkPlayer()
    {
        StartCoroutine(DoBlinks(2,0.2f));
    }

    IEnumerator DoBlinks(int numBlinks, float time)
    {
        for(int i =0;i < numBlinks*2;i++ )
        {
            foreach (Renderer component in myRenderer)
            {
                component.enabled = !component.enabled;
            }
            yield return new WaitForSeconds(time);
        } 
        
        //myRenderer.enabled = true;
        foreach (Renderer component in myRenderer)
            {
                component.enabled = true;
            }
    }

}
