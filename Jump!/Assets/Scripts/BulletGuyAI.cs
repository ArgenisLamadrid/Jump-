using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuyAI : MonoBehaviour {

    public float speed = 10f;

    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("player-body").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        // Turn to face the player
        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg -180;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
        
        // Move twoards the player
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
}
