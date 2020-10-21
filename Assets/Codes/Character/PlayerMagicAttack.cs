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
    public float magic2CDTime = 15f;
    private bool magic3Allowed = true;
    public float magic3CDTime = 10f;
    private MagicCDIcon1 icon1;
    private MagicCDIcon2 icon2;
    private MagicCDIcon3 icon3;
    
    //private bool xxAttackAllowed = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Swordman>();
        icon1 = GameObject.Find("Magic1Button").GetComponent<MagicCDIcon1>();
        icon2 = GameObject.Find("Magic2Button").GetComponent<MagicCDIcon2>();
        icon3 = GameObject.Find("Magic3Button").GetComponent<MagicCDIcon3>();
    }

    // Update is called once per frame
     void Update()
     {
        if (Input.GetKeyDown(KeyCode.R)&&magic1Allowed)
        {
                FireBallAttack();
                icon1.StartMagic();
        }
        if (Input.GetKeyDown(KeyCode.T)&&magic2Allowed)
        {
                magic2Magic();
                icon2.StartMagic();
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
     //Magic 2
     public void magic2Magic()
     {
         Instantiate(magic2, transform.position, transform.rotation);
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
         Instantiate(magic3, firePoint.position, firePoint.rotation);
         magic3Allowed = false;
         StartCoroutine(magic3CD());
     }

    IEnumerator magic3CD()
     {
         yield return new WaitForSeconds(magic3CDTime);
         magic3Allowed = true;
     }

}
