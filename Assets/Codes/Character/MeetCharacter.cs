using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MeetCharacter : MonoBehaviour
{
    public string ChatName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            Say();
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        
    }

    void Say(){
        PersistentData.update();
        Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        flowChart.ExecuteBlock(ChatName);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}