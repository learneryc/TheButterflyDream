using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMagic : MonoBehaviour
{
    public GameObject foot;
    public PlayerMagicAttack playermagic;
    public float lastTime;
    // Start is called before the first frame update
    void Start()
    {
        foot = GameObject.Find("Foot");
        playermagic = GameObject.Find("Jack").GetComponent<PlayerMagicAttack>();
        lastTime = playermagic.magic2LastTime;
        StartCoroutine(EndMagic());
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = foot.transform.position;
    }

    IEnumerator EndMagic()
     {
         yield return new WaitForSeconds(lastTime);
         Destroy(gameObject);
     }
}
