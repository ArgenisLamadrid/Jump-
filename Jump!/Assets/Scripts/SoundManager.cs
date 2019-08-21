using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static AudioClip playerFireSound,playerDeathSound, headGuyFireSound, playerThrusterSound,
     headGuyDeathSound, bulletGuyDeathSound, backgroundTrack1, backgroundTrack2, backgroundTrack3;
    static AudioSource audioSrc;

    // Use this for initialization
    void Start () {

        playerFireSound = Resources.Load<AudioClip>("laser4");
        headGuyFireSound = Resources.Load<AudioClip>("laser6");
        playerThrusterSound = Resources.Load<AudioClip>("SFX_Jump_09");
        headGuyDeathSound = Resources.Load<AudioClip>("explosion");
        bulletGuyDeathSound = Resources.Load<AudioClip>("boom3");
        playerDeathSound = Resources.Load<AudioClip>("Haha");

        audioSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound(string clip) {

        switch (clip) {
            case "playerFireSound":
                audioSrc.PlayOneShot(playerFireSound);
                break;
            case "headGuyFireSound":
                audioSrc.PlayOneShot(headGuyFireSound);
                break;
            case "playerThrusterSound":
                audioSrc.PlayOneShot(playerThrusterSound);
                break;
            case "headGuyDeathSound":
                audioSrc.PlayOneShot(headGuyDeathSound);
                break;
            case "bulletGuyDeathSound":
                audioSrc.PlayOneShot(bulletGuyDeathSound);
                break;
            case "playerDeathSound":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
        }
    }
}
