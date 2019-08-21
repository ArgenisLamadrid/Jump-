using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGuyAI : MonoBehaviour {
    private Rigidbody2D headGuyRigidBody2D;
    public float speed;
    private int goUpFirst;

    // Use this for initialization
    void Start () {

        goUpFirst = Random.Range(1, 3);

        headGuyRigidBody2D = GetComponent<Rigidbody2D>();
        if (goUpFirst == 1){  
            // Move Up
            headGuyRigidBody2D.AddForce(new Vector2(0f, speed));
        }
        else {
            // Move Down
            headGuyRigidBody2D.AddForce(new Vector2(0f, -speed));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ceiling"){
            // Move Down
            headGuyRigidBody2D.AddForce(new Vector2(0f, -speed));

        }
        else if (collision.gameObject.tag == "highway")
        {
            // Move Up
            headGuyRigidBody2D.AddForce(new Vector2(0f, speed));

        }
    }
}
