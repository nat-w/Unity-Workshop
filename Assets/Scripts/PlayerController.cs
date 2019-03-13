using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // how fast our player moves, play around with the value
    public int speed = 20;
    // player's rigidbody so we can push the player around to move
    private Rigidbody rigidBody;
    // the animator controller for the player
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // find both components of the player
        rigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // tell our animator we are not moving
        anim.SetBool("isWalking", false);

        // get input from the arrow keys
        float x_pos = Input.GetAxisRaw("Horizontal");
        float z_pos = Input.GetAxisRaw("Vertical");

        // where we want the player to move
        Vector3 new_pos = new Vector3(x_pos, 0, z_pos);
        
        // rotates the player in the direction they're moving
        // quaternions are a data type to store rotations,
        // they're a bit complicated so read the docs on how to use them
        Quaternion new_rot = Quaternion.LookRotation(new_pos, Vector3.up);
        
        // check if we've moved
        if (new_pos != Vector3.zero) {
            // tell the animator we're walking
            anim.SetBool("isWalking", true);
            // rotate the player smoothly
            transform.rotation = Quaternion.Slerp(transform.rotation, new_rot, 2.0f);
        }
        // move the player to the new position 
        transform.position += new_pos * Time.deltaTime * speed;
    }
}
