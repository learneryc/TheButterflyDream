﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private CircleCollider2D attackArea;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = GetComponent<CircleCollider2D>();
        damage = 1;
        AudioManager.instance.DelayPlay("Sound/magicFire", 0.1f);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Explode()
    {
        attackArea.enabled = true;

    }


    public void DestoryBomb()
    {
        attackArea.enabled = false;
        Destroy(gameObject ,0.1f);
    }

    // damage the range enemy and player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
           other.GetComponent<Swordman>().beAttacked(damage);
        }
        if(other.gameObject.CompareTag("Enemy")&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
        if(other.gameObject.CompareTag("Boss")&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            other.GetComponent<BossHealth>().TakeDamage(damage);
        }
    }
}
