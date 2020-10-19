using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPCControl : MonoBehaviour
{
    public string ChatName;
    private bool canChat = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        Say();
        canChat = false;
    }

    public void OnTriggerExit2D(Collider2D other){
        canChat = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.E)){
            Say();
        }
        */
    }

    void Say(){
        if(canChat){
        Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        flowChart.ExecuteBlock(ChatName);
        }
    }
}
