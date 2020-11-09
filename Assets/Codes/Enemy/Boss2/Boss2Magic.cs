using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss2Magic : MonoBehaviour
{
    public GameObject goblin1;
    public GameObject goblin2;
    public GameObject goblin3;
    public GameObject shieldAttack;

    public float cntTime = 0f ;
    public  float bossSkill1CD = 20f ;

    public Image bossMagicBar;
    public Transform magicStartPos;
    public Transform magicEndPos;
    private RectTransform barPos;

    // Start is called before the first frame update
    void Start()
    {
          barPos = bossMagicBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        barPos.position =new Vector2( magicStartPos.position.x + (magicEndPos.position.x - magicStartPos.position.x)* cntTime / bossSkill1CD     ,   magicEndPos.position.y );
    }
    
    public void callGoblin1()
    {
        GetComponent<Animator>().SetTrigger("Guard");
        Instantiate(goblin1,new Vector2(this.transform.position.x + 2,this.transform.position.y + 1),Quaternion.identity);
        Instantiate(goblin2,new Vector2(this.transform.position.x - 2,this.transform.position.y + 1),Quaternion.identity);
        //GetComponent<Animator>().ResetTrigger("Guard");
    }
    public void callGoblin2()
    {
        GetComponent<Animator>().SetTrigger("Guard");
        Instantiate(goblin1,new Vector2(this.transform.position.x + 2,this.transform.position.y + 1),Quaternion.identity);
        Instantiate(goblin3,new Vector2(this.transform.position.x - 2,this.transform.position.y + 1),Quaternion.identity);
        //GetComponent<Animator>().ResetTrigger("Guard");
    }

    public void callGoblin3()
    {
        GetComponent<Animator>().SetTrigger("Guard");
        Instantiate(goblin3,new Vector2(this.transform.position.x + 2,this.transform.position.y + 1),Quaternion.identity);
        Instantiate(goblin3,new Vector2(this.transform.position.x - 2,this.transform.position.y + 1),Quaternion.identity);
        //GetComponent<Animator>().ResetTrigger("Guard");
    }

    public void ShieldAttack()
    {
        transform.Rotate(0f, 180f, 0f);
         Instantiate(shieldAttack, this.transform.position, this.transform.rotation);
         transform.Rotate(0f, 180f, 0f);
    }
}
