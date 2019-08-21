using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeLaserController : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "laser-round" || collision.gameObject.tag == "player-body" || collision.gameObject.tag == "platform")
        {
            Destroy(gameObject);
        }
  
    }
}