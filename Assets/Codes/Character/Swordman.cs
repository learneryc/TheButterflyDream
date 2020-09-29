using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Swordman : PlayerController
{
    public string SceneName="GameOver";
	public Animator transition;
	public string trigger = "CrossFade";
	public float transitionTime = 1f;

    IEnumerator LoadLevel() {
		if (trigger!="") {
			transition.SetTrigger(trigger);
			yield return new WaitForSeconds(transitionTime);
		}
		if (SceneName != "") SceneManager.LoadScene(SceneName);
	}

    private void Start()
    {

        m_CapsulleCollider  = this.transform.GetComponent<CapsuleCollider2D>();
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();
  

    }



    private void Update()
    {
        checkAlive();

        checkInput();

        if (checkDropDown() && !isDroppedDown) {
            curHealth--;
            checkAlive();
            isDroppedDown = true;
            System.Threading.Thread.Sleep(600);
            Vector3 pos = m_rigidbody.position;
            pos.x = -6;
            pos.y = 4;
            m_rigidbody.position = pos;
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
//                if (currentJumpCount < JumpCount)  // 0 , 1
//                {
//
//                }
                  DownJump();
            }

            return;
        }


        m_MoveX = Input.GetAxis("Horizontal");


   
        GroundCheckUpdate();


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                m_Anim.Play("Attack");
                AudioManager.instance.Play("Sound/attackWithoutHitting", 1.0);
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


        if (Input.GetKey(KeyCode.RightArrow))
        {

            if (isGrounded)
            {



                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;

                transform.transform.Translate(Vector2.right* m_MoveX * MoveSpeed * Time.deltaTime);



            }
            else
            {

                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }




            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.LeftArrow))
                Filp(false);


        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {


            if (isGrounded)
            {



                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;


                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);

            }
            else
            {

                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }


            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.RightArrow))
                Filp(true);


        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!IsSit)
            {
                prefromJump();

            }
            else
            {
                DownJump();

            }

//            if (currentJumpCount < JumpCount)  // 0 , 1
//            {
//
//
//
//            }


        }



    }

    protected override void LandingEvent()
    {


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            m_Anim.Play("Idle");

    }

    public void beAttacked() {
        curHealth--;
        checkAlive();
    }

    public bool checkDropDown() {
        if (m_rigidbody.position.y < -10) {
            return true;
        } else {
            return false;
        }
    }

    private void checkAlive() {
        if(curHealth <= 0)
            StartCoroutine(LoadLevel());
    }


}
