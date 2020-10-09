using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;
    private Swordman jack;
    private BoxCollider2D attackArea;
    // Start is called before the first frame update
    void Start()
    {
        jack = GameObject.FindGameObjectWithTag("Player").GetComponent<Swordman>();
        attackArea = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if(jack != null)
            {   
                jack.beAttacked(damage);
                attackArea.enabled = false;
                StartCoroutine(RecoverAttackArea());
            }
        }
    }

    
    IEnumerator RecoverAttackArea()
    {   
        yield return new WaitForSeconds(2f);
        attackArea.enabled = true;
    }
}
