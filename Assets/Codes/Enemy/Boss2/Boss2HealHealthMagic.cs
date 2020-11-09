using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2HealHealthMagic : MonoBehaviour
{
    public GameObject foot;
    public float lastTime=1f;
    // Start is called before the first frame update
    void Start()
    {
        foot = GameObject.Find("Foot2");
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
