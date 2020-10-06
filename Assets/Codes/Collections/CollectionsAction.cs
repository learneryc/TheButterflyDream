using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionsAction : MonoBehaviour
{
	

	public bool pickUpAllowed ;
	public Text pickUpText;
    

    // Start is called before the first frame update
    public void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E)){
        	PickUp();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){
    	if(collision.gameObject.name.Equals("Jack")){
    		pickUpText.gameObject.SetActive(true);
    		pickUpAllowed = true;
    	}
    }

    public void OnTriggerExit2D(Collider2D collision){
    	if(collision.gameObject.name.Equals("Jack")){
    		pickUpText.gameObject.SetActive(false);
    		pickUpAllowed = false;
    	}
    }
    
    public void PickUp(){
        AudioManager.instance.Play("Sound/pickup");
    	Destroy(gameObject);
    }
}
