using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AutoMove : MonoBehaviour
{
    public float speed = 2; //[1] 物体移动速度
    public Transform []target;  // [2] 目标
    public float delta = 0.2f; // 误差值
    public string targetName;
    private static int i = 0;
    //protected Animator m_Anim;

    void Update () {
        moveTo ();  
    }

    void moveTo(){
        // [3] 重新初始化目标点
        target [i].position = new Vector3 (target [i].position.x, target [i].position.y, 0);

        if(target [i].position.x > 6){
        // [4] 让物体朝向目标点 
        transform.LookAt (target [i]);

        if(targetName.Equals("Rose")){
            Flowchart flowChart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            flowChart.ExecuteBlock("Wait");
        }

        // [5] 物体向前移动
        transform.Translate (Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(0f, -90f, 0f);

        // [6] 判断物体是否到达目标点
        if (transform.position.x > target[i].position.x - delta 
            && transform.position.x < target[i].position.x + delta
            )
            i = (i+1)%target.Length;
        }
        
    }
}
