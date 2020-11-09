using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Magic : MonoBehaviour
{
    public GameObject goblin1;
    public GameObject goblin2;
    public GameObject shieldAttack;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void callGoblin()
    {
        GetComponent<Animator>().SetTrigger("Guard");
        Instantiate(goblin1,new Vector2(this.transform.position.x + 2,this.transform.position.y + 1),Quaternion.identity);
        Instantiate(goblin2,new Vector2(this.transform.position.x - 2,this.transform.position.y + 1),Quaternion.identity);
        //GetComponent<Animator>().ResetTrigger("Guard");
    }

    public void ShieldAttack()
    {
        transform.Rotate(0f, 180f, 0f);
         Instantiate(shieldAttack, this.transform.position, this.transform.rotation);
         transform.Rotate(0f, 180f, 0f);
    }
}
