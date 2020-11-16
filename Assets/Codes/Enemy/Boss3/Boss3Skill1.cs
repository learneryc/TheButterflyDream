using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Skill1 : MonoBehaviour
{
    int m_damage = 1;
    private BoxCollider2D attackArea;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAttack(){
        attackArea.enabled = true;
    }

    public void EndAttack(){
        attackArea.enabled = false;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
           other.GetComponent<Swordman>().beAttacked(m_damage);
        }
    }
}
