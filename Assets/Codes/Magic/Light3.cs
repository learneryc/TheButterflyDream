using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light3 : MonoBehaviour
{
    public float lastTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndMagic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator EndMagic()
     {
         yield return new WaitForSeconds(lastTime);
         Destroy(gameObject);
     }
}
