using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPCControl : MonoBehaviour
{
    public string ChatName;
    public Transform player;
    private bool canChat = true;
    public bool isFlipped = false;
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
        LookAtPlayer();
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

    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
