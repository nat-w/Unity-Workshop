using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // This stores a reference to our player so we can get the player's position
    private GameObject player;
    // the offset is the distance from the player to the camera
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;

    }

    // Late Update is called after Update
    void LateUpdate()
    {
        // moves the camera alongside the player
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.1f);
    }
}
