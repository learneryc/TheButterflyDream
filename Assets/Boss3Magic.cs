using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss3Magic : MonoBehaviour
{
    //

    public float cntTime = 0f ;
    private  float boss3CD = 10f ;
    public  float boss3IdleCD = 5f ;
    public  float boss3ChantCD = 10f ;
    public Image bossMagicBar1;
    public Transform magicStartPos;
    public Transform magicEndPos;
    private RectTransform barPos;
    public GameObject bossStage1;
    public GameObject bossStage2_1;
    public GameObject bossStage2_2;
    enum boss3stage{
        chant,
        idle
    }
    boss3stage bossStage = boss3stage.chant;

    // Start is called before the first frame update
    void Start()
    {
        bossMagicBar1.sprite = Resources.Load("boss3Logo1", typeof(Sprite)) as Sprite; 
        boss3CD = boss3ChantCD;
        barPos = bossMagicBar1.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    bool skill1 =true;
    bool skill2 = true;
    void Update()
    {
        cntTime += Time.deltaTime;
        if(bossStage ==boss3stage.chant && (cntTime <=5f&&skill1) ||(skill2 && cntTime >=5f) ){
            int a = Random.Range(0,4)%3;
            switch (a)
            {
                case 0:{
                    GetComponent<Boss3Attack>().LightningAttack();
                    break;
                }
                case 1:{
                    GetComponent<Boss3Attack>().CallGoblin1();
                    break;
                }
                case 2:{
                    GetComponent<Boss3Attack>().CallGoblin2();
                    break;
                }
                default:{
                    break;
                }
            }
            if(!skill1 &&skill2){
                skill2 = false;
            }
            if(skill1){
                skill1 = false;
            }
            //Debug.Log(a);
            
            
        }

        if(bossStage ==boss3stage.chant && cntTime >= boss3CD){
            cntTime = 0;
            bossStage = boss3stage.idle;
            bossStage1.SetActive(false);
            bossMagicBar1.sprite = Resources.Load("boss3Logo2", typeof(Sprite)) as Sprite; 
            bossStage2_1.SetActive(true);
            bossStage2_2.SetActive(true);
            boss3CD = boss3IdleCD;
            // skill 
             skill2 = true;
             skill1 = true;
            
        }
        if(bossStage ==boss3stage.idle && cntTime >= boss3CD){
            GetComponent<Boss3Health>().maxdamage = 10;
            cntTime = 0;
            bossStage = boss3stage.chant;
            bossStage1.SetActive(true);
            bossMagicBar1.sprite = Resources.Load("boss3Logo1", typeof(Sprite)) as Sprite; 
            bossStage2_1.SetActive(false);
            bossStage2_2.SetActive(false);
            boss3CD = boss3ChantCD;
            GetComponent<Boss3Attack>().EndLightningAttack();
            
        }
        barPos.position =new Vector2( magicStartPos.position.x + (magicEndPos.position.x - magicStartPos.position.x)* cntTime / (boss3CD )     ,   magicEndPos.position.y );
    }
}
