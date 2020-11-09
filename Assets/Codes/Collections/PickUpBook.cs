using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class PickUpBook : MonoBehaviour
{
    public string ChatName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            PickUp();
            Say();
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //canChat = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Say(){
        Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        flowChart.ExecuteBlock(ChatName);
    }

    void PickUp(){
        PersistentData.setMagic2(1);
        AudioManager.instance.Play("Sound/pickup");
    	Destroy(gameObject);
    }
}
