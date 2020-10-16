using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    //private CircleCollider2D attackArea;
    public int damage ;
    public float speed;
    public float distance = 5f;
    Vector2 pos ;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         pos = transform.position;
         rb.velocity = transform.right * speed;
    }



    // Update is called once per frame
    void Update()
    {
        //transform.position  =  Vector2.MoveTowards(transform.position,transform,speed * Time.fixedDeltaTime);
        if(Vector2.Distance(transform.position,pos) > distance){
            Destroy(gameObject);
        }
    }
    

    // damage the range enemy and player
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Boss")&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"){
            other.GetComponent<BossHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
