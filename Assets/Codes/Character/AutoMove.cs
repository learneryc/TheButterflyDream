using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AutoMove : MonoBehaviour
{
    public float speed = 2; 
    public Transform []target;  
    public float delta = 0.2f; 
    public string targetName;
    private static int i = 0;
    //protected Animator m_Anim;

    void Update () {
        moveTo ();  
    }

    void moveTo(){
        target [i].position = new Vector3 (target [i].position.x, target [i].position.y, 0);

        if(target [i].position.x > 6){
        
        transform.LookAt (target [i]);

        if(targetName.Equals("Rose")){
            Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            flowChart.ExecuteBlock("Wait");
        }

        transform.Translate (Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(0f, -90f, 0f);

        if (transform.position.x > target[i].position.x - delta 
            && transform.position.x < target[i].position.x + delta
            )
            i = (i+1)%target.Length;
        }
        
    }
}
