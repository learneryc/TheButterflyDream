﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	public int damage;
	PolygonCollider2D collider2D;


    // Start is called before the first frame update
    void Start()
    {
        collider2D = GameObject.FindGameObjectWithTag("Weapon").GetComponent<PolygonCollider2D>();
        damage = 2;
    }

    // Update is called once per frame
    void Update()
    {
        AttackWithWeapon();
    }

    void AttackWithWeapon(){
        if (Input.GetKey(KeyCode.Mouse0)){
            collider2D.enabled = true;
            StartCoroutine(DisableWeapon());
        }

    }
    IEnumerator DisableWeapon(){
        yield return new WaitForSeconds(0.5f);
        collider2D.enabled = false;
    }

    public int getDamage(){
        return damage;
    }
    


    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
