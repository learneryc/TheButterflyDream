using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Skill1 : MonoBehaviour
{
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
        if(Vector2.Distance(transform.position,pos) > distance){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
           other.GetComponent<Swordman>().beAttacked(damage);
           Destroy(gameObject);
        }
	}
   
}
