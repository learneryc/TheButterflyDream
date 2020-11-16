using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Move : MonoBehaviour
{
    public Transform initalPos;
    Vector2 target ;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(initalPos.position.x +Random.Range(-1f, 1f)  , initalPos.position.y+Random.Range(-1f, 1f) );
    }

    // Update is called once per frame
    void Update()
    {
         if(Vector2.Distance(transform.position,target ) < 0.1f){
             target = new Vector2(initalPos.position.x +Random.Range(-1f, 1f)  , initalPos.position.y+Random.Range(-1f, 1f) );
         }
        transform.position =  Vector2.MoveTowards(transform.position,target, speed * Time.deltaTime);
    }
}
