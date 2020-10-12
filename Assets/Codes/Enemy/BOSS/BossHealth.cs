﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public bool isInvulnerable = false;
    public int health = 20;
    public GameObject deathEffect;
    public SpriteRenderer[] sr;
    public Color[] originalColor;

    public void Start()
    {
        sr = GetComponentsInChildren<SpriteRenderer>();
        originalColor = new Color[sr.Length];
        for(int i =0;i<sr.Length;i++)
        {
            originalColor[i] = sr[i].color;
        }
        
    }
    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;
        FlashColor(0.2f);
		health -= damage;

		if (health <= 10)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			//GetComponent<Animator>().SetTrigger("Dead");
            Destroy(gameObject,0.1f);
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
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
}