using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuyController : MonoBehaviour {

    public float health = 100f;
    public float damageTaken = 101f;
    private bool playDeathSound = true;

    public Animator animate;

	// Use this for initialization
	void Start () {
        animate.SetFloat("bulletGuyHealth", health);
    }
	
	// Update is called once per frame
	void Update () {

        // Check for death
        if (health < 0)
        {
            if (playDeathSound == true)
            {
                SoundManager.PlaySound("bulletGuyDeathSound");
                playDeathSound = false;
            }
            StartCoroutine(Death(.444f));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "laser-round")
        {
            Destroy(collision.gameObject, .0001f);
            health -= damageTaken;
            animate.SetFloat("bulletGuyHealth", health);
        }
        else if (collision.gameObject.tag == "player-body" || collision.gameObject.tag == "platform")
        {
            health -= damageTaken;
            animate.SetFloat("bulletGuyHealth", health);
        }

    }

    // Waits for certain amount of time for animation, then destoys object
    IEnumerator Death(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
