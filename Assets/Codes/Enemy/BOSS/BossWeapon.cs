using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 1;
	public bool attackAllowed = true;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	private Swordman jack;
	private BoxCollider2D attackArea;

	public void Start(){
		jack = GameObject.FindGameObjectWithTag("Player").GetComponent<Swordman>();
		attackArea = GetComponent<BoxCollider2D>();
	}
	public void AttackWithWeapon()
	{
		attackAllowed = false;
		StartCoroutine(ResetAttack());
	}
	IEnumerator ResetAttack()
    {
		yield return new WaitForSeconds(1f);
		attackAllowed = true;
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
	// public void Attack()
	// {
	// 	Vector3 pos = transform.position;
	// 	pos += transform.right * attackOffset.x;
	// 	pos += transform.up * attackOffset.y;

	// 	Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
	// 	if (colInfo != null)
	// 	{
	// 		//jack.beAttacked(attackDamage);
	// 		colInfo.GetComponent<Swordman>().beAttacked(attackDamage);
	// 	}
	// }
	// void OnDrawGizmosSelected()
	// {
	// 	Vector3 pos = transform.position;
	// 	pos += transform.right * attackOffset.x;
	// 	pos += transform.up * attackOffset.y;

	// 	Gizmos.DrawWireSphere(pos, attackRange);
	// }
}
