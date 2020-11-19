using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    public GameObject magic1;
    public GameObject magic2;
    public GameObject magic3;
    public GameObject healhealth;
    private Swordman player;
    public Transform firePoint;
    private bool magic1Allowed = true;
    public float magic1CDTime = 5f;
    private bool magic2Allowed = true;
    public float magic2CDTime = 5f;
    public float magic2LastTime = 5f;
    private bool magic3Allowed = true;
    public float magic3CDTime = 10f;
    public float healHealthLastTime = 1.5f;
    private int potionCounter = 0;

    // magic2
    private Animator anim;
    
    
    //private bool xxAttackAllowed = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Swordman>();
        anim = this.transform.Find("model").GetComponent<Animator>();
    }

    // Update is called once per frame
     void Update()
     {
         if(Input.GetKeyDown(KeyCode.M)){
             getHeal();
         }
     }
     //Magic 1
     public void FireBallAttack()
     {
        Instantiate(magic1, firePoint.position, firePoint.rotation);
        magic1Allowed = false;
        StartCoroutine(magic1CD());
     }
     IEnumerator magic1CD()
     {
         yield return new WaitForSeconds(magic1CDTime);
         magic1Allowed = true;
     }


     //Magic 2 -> double the damage but also double the hurt 
     public void magic2Magic()
     {
         //anim.Play("Enrage1");
         anim.SetFloat("PlayerAttackSpeed",3.0f);
         magic2Allowed = false;
         Instantiate(magic2, firePoint.position, firePoint.rotation);
         StartCoroutine(magic2CD());
         StartCoroutine(recoverAttackSpeed());
     }

    IEnumerator recoverAttackSpeed()
     {
         yield return new WaitForSeconds(5f);
         anim.SetFloat("PlayerAttackSpeed",1.0f);
     }
    IEnumerator magic2CD()
     {
         yield return new WaitForSeconds(magic2CDTime);
         magic2Allowed = true;
     }


     
     //Magic 3
     public void magic3Magic()
     {
         //Instantiate(magic3, firePoint.position, firePoint.rotation);
         magic3Allowed = false;
         StartCoroutine(magic3CD());
     }

    IEnumerator magic3CD()
     {
         yield return new WaitForSeconds(magic3CDTime);
         magic3Allowed = true;
     }

     public void getHeal()
     {
         if(player.curHealth == 10)return;
         Instantiate(healhealth,transform.position,Quaternion.identity);
         player.curHealth  = player.curHealth + 1;
         potionCounter = PlayerPrefs.GetInt("potionCounter");
         potionCounter--;
         PlayerPrefs.SetInt("potionCounter", potionCounter);
     }

}
