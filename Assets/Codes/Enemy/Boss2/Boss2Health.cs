using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2Health : MonoBehaviour
{

    public bool isInvulnerable = false;
    public int health = 40;
    protected SpriteRenderer[] sr;
    protected Color[] originalColor;
    public Image healthBar1;
    public Image healthBar2;
    public GameObject bossHealth;
    private Boss2Magic bossmagic;
    public GameObject healMagic;
    // Start is called before the first frame update
    void Start()
    {
        bossmagic = GetComponent<Boss2Magic>();
        sr = GetComponentsInChildren<SpriteRenderer>();
        originalColor = new Color[sr.Length];
        for(int i =0;i<sr.Length;i++)
        {
            originalColor[i] = sr[i].color;
        }
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
    bool callgoblinlevel1 = true;
    bool callgoblinlevel2 = true;
    bool callgoblinlevel3 = true;
    bool callgoblinlevel4 = true;

    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;
        FlashColor(0.2f);
		health -= damage;
        if(callgoblinlevel1 && health <=30 ){
            bossmagic.callGoblin1();
            callgoblinlevel1 = false;
        }
        if(callgoblinlevel2 && health <=20 ){
            bossmagic.callGoblin2();
            callgoblinlevel2 = false;
        }
        if(callgoblinlevel3 && health <=10 ){
            bossmagic.callGoblin2();
            callgoblinlevel3 = false;
        }
        if(callgoblinlevel4 && health <=5 ){
            bossmagic.callGoblin3();
            callgoblinlevel4 = false;
        }

		if (health <= 0)
		{
             GetComponent<Animator>().SetTrigger("Die");
            AudioManager.instance.Play("Sound/bossWin", 1.0);
            bossHealth.SetActive(false);
			// GetComponent<Animator>().SetTrigger("Dead");
            //Destroy(gameObject);
            
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

    public void GetHeal(int healamount)
	{
        if(health + healamount <=40)
        {
            health += healamount;
            Instantiate(healMagic,this.transform.position,Quaternion.identity);
        }else{
            health = 40;
        }
    }
}
