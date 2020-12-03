using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Boss3Health : MonoBehaviour
{

    public bool isInvulnerable = false;
    public int health = 40;
    protected SpriteRenderer[] sr;
    protected Color[] originalColor;
    public Image healthBar1;
    public Image healthBar2;
    public GameObject bossHealth;
    public int maxdamage = 10;

    //
    public GameObject bossStage2_1;
    public GameObject bossStage2_2;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentsInChildren<SpriteRenderer>();
        originalColor = new Color[sr.Length];
        for(int i =0;i<sr.Length;i++)
        {
            originalColor[i] = sr[i].color;
        }
        bossStage2_1.SetActive(false);
        bossStage2_2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(health >20){
            healthBar1.fillAmount = (float)(health-20) / 20.0f;
            healthBar2.fillAmount = 1f;
        }else if(health <=20 && health >=0){
            healthBar2.fillAmount = (float)health / 20.0f;
            healthBar1.fillAmount = 0;
        }else {
            healthBar1.fillAmount = 0;
            healthBar2.fillAmount = 0;
        }

    }

    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
		return;
        if(maxdamage <=0)
        return;
        FlashColor(0.2f);
		health -= damage;
        maxdamage -=damage;
		if (health <= 0)
		{
            // GetComponent<Animator>().SetTrigger("Die");
            AudioManager.instance.Play("Sound/bossWin", 1.0);
            bossHealth.SetActive(false);
            Destroy(gameObject);
            // RunAway();
            SayStory();
		}
	}

    public void FlashColor(float time)
    {
        for(int i =0 ; i< sr.Length ;i++)
        {
            sr[i].color = Color.red;
        }
        Invoke("ResetColor",time);
    }

    public void ResetColor()
    {
        for(int i =0 ; i< sr.Length ;i++)
        {
            sr[i].color = originalColor[i];
        }
    }

    public void SayStory(){
        Flowchart fc = GameObject.Find("Flowchart").GetComponent<Fungus.Flowchart>();
        fc.ExecuteBlock("Ending");
    }


}
