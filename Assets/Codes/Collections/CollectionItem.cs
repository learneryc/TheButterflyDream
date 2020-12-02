using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : CollectionsAction
{
    private Fungus.Flowchart fc;
    public string BlockName;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        fc = GameObject.Find("Flowchart").GetComponent<Fungus.Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E)){
        	PickUp();
        }
        
    }

    void PickUp(){
        
        if (pickUpAllowed){
            base.PickUp();
            //PersistentData.update();
            fc.ExecuteBlock(BlockName);
        }
        
    }
}
