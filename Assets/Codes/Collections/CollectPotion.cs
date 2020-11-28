using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPotion : CollectionsAction
{
    private int potionCounter = 0;
    // Start is called before the first frame update
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

    void PickUp(){
        if (pickUpAllowed) {
            AudioManager.instance.Play("Sound/pickup");
            Destroy(gameObject);
            potionCounter = PlayerPrefs.GetInt("potionCounter", 0);
            potionCounter++;
            PlayerPrefs.SetInt("potionCounter", potionCounter);
        }
    }
}
