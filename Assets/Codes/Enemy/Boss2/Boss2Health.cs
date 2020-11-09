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
    private Image healthBar;
    public GameObject bossHealth;
    public Boss2Magic bossmagic;
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
        
    }
    bool callgoblinlevel1 = true;
    bool callgoblinlevel2 = true;
    bool callgoblinlevel3 = true;

    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;
        FlashColor(0.2f);
		health -= damage;
        if(callgoblinlevel1 && health <=30 ){
            bossmagic.callGoblin();
            callgoblinlevel1 = false;
        }
        if(callgoblinlevel2 && health <=20 ){
            bossmagic.callGoblin();
            callgoblinlevel2 = false;
        }
        if(callgoblinlevel3 && health <=10 ){
            bossmagic.callGoblin();
            callgoblinlevel3 = false;
        }

		if (health <= 20)
		{
			//GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
            //photo.SetActive(true);
            AudioManager.instance.Play("Sound/bossWin", 1.0);
            //bossHealth.SetActive(false);
			// GetComponent<Animator>().SetTrigger("Dead");
            Destroy(gameObject);
            
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
}
