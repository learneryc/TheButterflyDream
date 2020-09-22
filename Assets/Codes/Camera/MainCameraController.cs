using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public GameObject player;

    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 player_pos = player.transform.position;
        Vector3 camera_pos = transform.position;
        offset = camera_pos.x - player_pos.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_pos = player.transform.position;
        Vector3 camera_pos = transform.position;
        camera_pos.x = player_pos.x + offset;
        transform.position = camera_pos;
    }
}
