﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    public GameObject fireAttack;
    private Swordman player;
    public Transform firePoint;
    private bool fireAttackAllowed = true;
    public float fireAttackCDTime = 5f;
    //private bool xxAttackAllowed = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Swordman>();
    }

    // Update is called once per frame
     void Update()
     {
        if (Input.GetKeyDown(KeyCode.R)&&fireAttackAllowed)
        {
                Instantiate(fireAttack, firePoint.position, firePoint.rotation);
                fireAttackAllowed = false;
                StartCoroutine(FireAttackCD());
            
        }
     }

     // CD for each magic
     IEnumerator FireAttackCD()
     {
         yield return new WaitForSeconds(fireAttackCDTime);
         fireAttackAllowed = true;
     }
}