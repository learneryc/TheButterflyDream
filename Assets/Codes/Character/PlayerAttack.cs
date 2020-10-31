using System.Collections;
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
        damage = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //AttackWithWeapon();
    }
    //
    public void AttackStart(){
         collider2D.enabled = true;
    }
    public void AttackEnd(){
        collider2D.enabled = false;
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
        if(other.gameObject.CompareTag("Enemy")&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            other.GetComponent<Enemy>().TakeDamage(damage); 
        }
         if(other.gameObject.CompareTag("Goblin")&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            other.GetComponent<Goblin_Bass>().TakeDamage(damage);
        }
        if(other.gameObject.CompareTag("Boss")&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            other.GetComponent<BossHealth>().TakeDamage(damage);
        }
    }
}
