using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Stage2Move : MonoBehaviour
{
    public Transform initalPos;
    public float speed = 0.1f;
    Vector2 target ;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(initalPos.position.x +Random.Range(-1f, 1f)  , initalPos.position.y );
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,target ) < 0.1f){
             target = new Vector2(initalPos.position.x +Random.Range(-1f, 1f)  , initalPos.position.y );
         }
        transform.position =  Vector2.MoveTowards(transform.position,target, speed * Time.deltaTime);
    }
}
