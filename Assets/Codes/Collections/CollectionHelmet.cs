using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHelmet : CollectionsAction
{
    public GameObject photo;
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
        	PickUp();
            photo.SetActive(true);;
            PersistentData.setMagic1(1);
        }
    }
}
