using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController2 : MonoBehaviour
{
    public GameObject player;

    private float offset;
    private float offset_y;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 player_pos = player.transform.position;
        Vector3 camera_pos = transform.position;
        offset = camera_pos.x - player_pos.x;
        offset_y = camera_pos.y - player_pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_pos = player.transform.position;
        Vector3 camera_pos = transform.position;
        camera_pos.x = player_pos.x + offset;
        camera_pos.y = player_pos.y + offset_y;
        transform.position = camera_pos;
    }
}