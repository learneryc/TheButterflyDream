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

        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
            PersistentData.update();
            fc.ExecuteBlock(BlockName);
        	PickUp();
        }
        
    }

    void PickUp(){
        
            /*GameObject.Find("LevelLoader").
            GetComponent<LevelLoader>().MoveToNextLevel();
            PersistentData.update();*/
        AudioManager.instance.Play("Sound/pickup");
    	Destroy(gameObject);
    }
}
