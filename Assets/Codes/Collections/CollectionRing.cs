using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionRing : CollectionsAction
{
    private Fungus.Flowchart fc;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        fc = GameObject.Find("Flowchart").GetComponent<Fungus.Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {

        /*if(pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
            PersistentData.update();
            fc.ExecuteBlock("Ring");
        	PickUp();
        }*/
        if (Input.GetKeyDown(KeyCode.E)){
            PersistentData.update();
            PickUp();
        }
    }

    void PickUp(){
        
        if (pickUpAllowed) {
            AudioManager.instance.Play("Sound/pickup");
            fc.ExecuteBlock("Ring");
            Destroy(gameObject);
        }
        
    }
}
