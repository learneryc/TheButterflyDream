using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Attack : MonoBehaviour
{
    public float cntTime = 0f ;
    public GameObject Boss3;
    int health;
    public bool attackAllowed = true;
    public float CallGoblinCD = 5f;
    public float LightningAttackCD = 4.9f;
    public float LightningAttackIntrvalCD = 2f;
    private bool LightningTime = false;
    private GameObject  player;


    public GameObject lightning;

    public GameObject goblin1;
    public GameObject goblin2;
    public GameObject goblin3;
    public GameObject goblinPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!LightningTime)return;
        cntTime += Time.deltaTime;
        if(cntTime > LightningAttackIntrvalCD)
        {
            Instantiate(lightning,new Vector2(player.transform.position.x + Random.Range(-1.5f, 1.5f) ,0.6f),Quaternion.identity);
            cntTime= 0;
        }
        
    }

    public void CallGoblin1(){
        Instantiate(goblin1,new Vector2(goblinPos.transform.position.x ,-2.8f),Quaternion.identity);
        //Instantiate(goblin2,new Vector2(goblinPos.transform.position.x ,-2.8f),Quaternion.identity);
    }
    public void CallGoblin2(){
        //Instantiate(goblin3,new Vector2(goblinPos.transform.position.x ,-2.8f),Quaternion.identity);
        Instantiate(goblin2,new Vector2(goblinPos.transform.position.x ,-2.8f),Quaternion.identity);
    }
    public void LightningAttack(){
        LightningTime = true;
        Invoke("StopLightning",LightningAttackCD);
    }

    public void EndLightningAttack(){
        LightningTime = false;
    }
    void StopLightning(){
        LightningTime = false;
    }
}
