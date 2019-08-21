using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGuyController : MonoBehaviour {

    private float elapsedTime = 0f;
    public float fireDelay = 5f;
    public float roundSpeed = 8f;
    public float health = 100f;
    private bool playDeathSound = true;

    public GameObject largeLaserRound;
    public GameObject laserSpawn;
    public Animator animate;

    // Use this for initialization
    void Start () {
        animate.SetFloat("headGuyHealth", health);
    }
	
	// Update is called once per frame
	void Update () {

        // Check for death
        if (health < 0) {
            if (playDeathSound == true) {
                SoundManager.PlaySound("headGuyDeathSound");
                playDeathSound = false;
            }
            Death(.5f);
        }
        // Check to see if enough time has passed to fire again
        elapsedTime += Time.deltaTime;

        if (elapsedTime > fireDelay) {
            SoundManager.PlaySound("headGuyFireSound");
            FireRound();
            elapsedTime = 0f;
        }

	}


    private void FireRound()
    {
        var round = Instantiate(largeLaserRound, laserSpawn.transform.position, Quaternion.identity);
        Rigidbody2D largeLaserRoundRigidBody = round.GetComponent<Rigidbody2D>();
        largeLaserRoundRigidBody.velocity = Vector3.left * roundSpeed;
    }

    // Update health, destroy player laser round, ignore other objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "laser-round")
        {
            Destroy(collision.gameObject, .001f);
            health -= 75f;
            animate.SetFloat("headGuyHealth", health);
        }

    }

    // Waits for certain amount of time for animation, then destoys object
     private void Death(float time) {
        Destroy(gameObject,time);
    }

}
