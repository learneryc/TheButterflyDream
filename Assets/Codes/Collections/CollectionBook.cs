using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionBook : CollectionsAction
{
    public Button magic2 ; 
    // Start is called before the first frame update
    void Start()
    {
         base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
            PersistentData.setMagic2(1);
            magic2.gameObject.SetActive(true);
            AudioManager.instance.Play("Sound/pickup");
    	    Destroy(gameObject);
        }
    }
 
}
