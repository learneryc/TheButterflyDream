using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHelmet : CollectionsAction
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
        	PickUp();
        }
    }
}
