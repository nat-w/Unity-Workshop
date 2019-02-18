using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Vector3 direction;
    private int speed = 5;

    void Start()
    {
        StartCoroutine("wait");
    }

    void Update()
    {

    }

    IEnumerator wait() {
        yield return new WaitForSeconds(5f);
        
        direction = new Vector3(Random.Range(-1,2),0,Random.Range(-1,2));
        Quaternion new_rot = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, new_rot, 2.0f);
        transform.position += direction * speed * Time.deltaTime;
    }
}
