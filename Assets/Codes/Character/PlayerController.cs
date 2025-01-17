﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController :MonoBehaviour
{
    public bool IsSit = false;
    public int currentJumpCount = 0; 
    public bool isGrounded = true;
    public bool OnceJumpRayCheck = false;
    public bool isDroppedDown = false;

    public bool Is_DownJump_GroundCheck = false;
    protected float m_MoveX;
    public Rigidbody2D m_rigidbody;
    protected CapsuleCollider2D m_CapsulleCollider;
    protected Animator m_Anim;
    protected Collider2D m_weapon;
    protected bool m_FacingRight = true;
    [Header("[Setting]")]
    public int curHealth = 10;
    public float MoveSpeed = 6;
    public int JumpCount = 2;
    public float jumpForce = 15f;

    protected void AnimUpdate()
    {


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {


                m_Anim.Play("Attack");
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

    }





	protected void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;
		transform.localScale = flipped;

		transform.Rotate(0f, 180f, 0f);
	}

    protected void prefromJump()
    {
        AudioManager.instance.Play("Sound/jumping");

        m_Anim.Play("Jump");

        m_rigidbody.velocity = new Vector2(0, 0);

        m_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        OnceJumpRayCheck = true;
        isGrounded = false;


        currentJumpCount++;

    }

    protected void DownJump()
    {
        if (!isGrounded)
            return;


        if (!Is_DownJump_GroundCheck)
        {
            m_Anim.Play("Jump");

            m_rigidbody.AddForce(-Vector2.up * 10);
            isGrounded = false;

            m_CapsulleCollider.enabled = false;

            StartCoroutine(GroundCapsulleColliderTimmerFuc());
        }


    }

    IEnumerator GroundCapsulleColliderTimmerFuc()
    {
        yield return new WaitForSeconds(0.3f);
        m_CapsulleCollider.enabled = true;
    }


    Vector2 RayDir = Vector2.down;


    float PretmpY;
    float GroundCheckUpdateTic = 0;
    float GroundCheckUpdateTime = 0.01f;
    protected void GroundCheckUpdate()
    {
        if (!OnceJumpRayCheck)
            return;

        GroundCheckUpdateTic += Time.deltaTime;



        if (GroundCheckUpdateTic > GroundCheckUpdateTime)
        {
            GroundCheckUpdateTic = 0;

            if (PretmpY == 0)
            {
                PretmpY = transform.position.y;
                return;
            }

            float reY = transform.position.y - PretmpY;

            if (reY <= 0)
            {

                if (isGrounded)
                {
                    LandingEvent();
                    OnceJumpRayCheck = false;
                }
                else
                {

//                    Debug.Log("Not at ground");

                }


            }


            PretmpY = transform.position.y;

        }




    }



    protected abstract void LandingEvent();


}
