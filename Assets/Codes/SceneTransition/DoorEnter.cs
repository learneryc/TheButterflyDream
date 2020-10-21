using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorEnter : MonoBehaviour
{
    public Transform backDoor;

    private Transform playerTransform;

    private bool isDoor;

    public Text enterDoorText;

    // Start is called before the first frame update
    void Start()
    {
        enterDoorText.gameObject.SetActive(false);
        playerTransform = GameObject.Find("Jack").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && isDoor) {
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
            enterDoorText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isDoor = false;
            enterDoorText.gameObject.SetActive(false);
        }
    }
}
