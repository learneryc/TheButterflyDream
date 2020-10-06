using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJinn : Enemy
{

    public float speed;
    public float waitTime;
    public Transform[] movePos;
    private int i = 0;
    private bool moveingRight = true;
    private float wait;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        wait = waitTime ; 

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        transform.position =  Vector2.MoveTowards(transform.position,movePos[i].position, speed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position,movePos[i].position ) < 0.1f)
        {
            if(waitTime >= 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                i++ ;
                if ( i == movePos.Length)
                {
                    i = 0;
                }
                // change direct 
                if(moveingRight){
                    if( movePos[i].position.x > transform.position.x)
                    {
                        transform.eulerAngles = new Vector3(0,-180,0);
                        moveingRight = false;
                    }
                }
                else
                {
                    if( movePos[i].position.x < transform.position.x)
                    {
                        transform.eulerAngles = new Vector3(0,0,0);
                        moveingRight = true;
                    }
                }

                

                waitTime  = wait;
            }
        }

    }
}
