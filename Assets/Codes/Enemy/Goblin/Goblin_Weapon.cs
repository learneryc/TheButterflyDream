using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    private PolygonCollider2D attackArea;
    public int attackDamage =1;
    void Start()
    {
        attackArea = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(){
		attackArea.enabled = true;
	}
	public void AfterAttack(){
		attackArea.enabled = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
           other.GetComponent<Swordman>().beAttacked(attackDamage);
        }
	}
}
