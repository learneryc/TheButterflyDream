using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    public Transform backDoor;

    private Transform playerTransform;

    private bool isDoor;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Jack").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I) && isDoor) {
            Vector3 pos = playerTransform.position;
            pos.x = backDoor.position.x;
            pos.y = backDoor.position.y - 0.8f;
            playerTransform.position = pos;
            Debug.Log(playerTransform.position);
            System.Threading.Thread.Sleep(100);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isDoor = false;
        }
    }
}
