using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 20;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_pos = Input.GetAxisRaw("Horizontal");
        float z_pos = Input.GetAxisRaw("Vertical");

        float x_prev = x_pos;
        float z_prev = z_pos;

        Vector3 new_pos = new Vector3(x_prev, 0, z_prev);

        Quaternion new_rot = Quaternion.LookRotation(new_pos, Vector3.up);
        
        if (new_pos != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, new_rot, 2.0f);

        transform.position += new_pos * Time.deltaTime * speed;
    }
}
