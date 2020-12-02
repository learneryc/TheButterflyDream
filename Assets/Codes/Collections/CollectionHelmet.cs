using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHelmet : CollectionsAction
{
    public GameObject photo;
    public GameObject playerhelmet; 
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
        	PickUp();
            
        }
    }

    void PickUp() {
        
        if (pickUpAllowed) {
            base.PickUp();
            playerhelmet.SetActive(true);
            photo.SetActive(true);
            PersistentData.setMagic1(1);
        }
    }
}
