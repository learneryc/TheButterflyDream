using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    public GameObject magic1;
    public GameObject magic2;
    public GameObject magic3;
    private Swordman player;
    public Transform firePoint;
    private bool magic1Allowed = true;
    public float magic1CDTime = 5f;
    private bool magic2Allowed = true;
    public float magic2CDTime = 1f;
    private bool magic3Allowed = true;
    public float magic3CDTime = 10f;

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
         magic2Allowed = false;
         StartCoroutine(magic2CD());
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

}
