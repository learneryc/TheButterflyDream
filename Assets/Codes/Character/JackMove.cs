using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackMove : MonoBehaviour
{
    public Rigidbody2D pl;   //刚体

    public float jumpForce ;  //跳跃的力

    public float horizontal;  //水平偏移量

    public float moveSpeed; //水平移动速度绝对值

    public float move; //水平移动速度（左 或 右）

    public bool faceRight = true;


    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<Rigidbody2D>();   //获取主角刚体组件
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");   //水平方向按键偏移量
        Move(horizontal);
    }

    void Move(float horizontal)
    {
        //if(!Mathf.Approximately(0, horizontal))
        //    transform.rotation = horizontal > 0 ? Quaternion.Euler(0, 180, 0): Quaternion.identity;
        /*
        角色反转功能，暂时有bug，角色转向的时候会瞬移
        if(faceRight & horizontal < 0){
            faceRight = !faceRight;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(!faceRight & horizontal >= 0){
            faceRight = !faceRight;
            transform.rotation = Quaternion.identity;
        }
        */

        move = horizontal * moveSpeed;   //刚体具体速度

        pl.velocity = new Vector2(move, pl.velocity.y);

        Jump();
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)) {    //如果按下空格
            // AudioManager.instance.Play("Sound/jumping");
            pl.AddForce(new Vector2(0,jumpForce));   //给刚体一个向上的力
        }
    }

}
