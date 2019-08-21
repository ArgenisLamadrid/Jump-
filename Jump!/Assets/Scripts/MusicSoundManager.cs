using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundManager : MonoBehaviour {

    public static AudioClip  backgroundTrack1, backgroundTrack2, backgroundTrack3;
    static AudioSource musicSrc;
    private int trackNumber = 3;

    // Use this for initialization
    void Start () {

        backgroundTrack1 = Resources.Load<AudioClip>("wyver9_Arcade Level(8-bit)");
        backgroundTrack2 = Resources.Load<AudioClip>("wyver9_Beat&#039;em Up Level");
        backgroundTrack3 = Resources.Load<AudioClip>("wyver9_Thorns&#039;n&#039;Ropes(8-bit)");

        musicSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!musicSrc.isPlaying && trackNumber == 3) {
            PlaySound("backgroundTrack1");
            trackNumber = 1;
            Debug.Log(trackNumber);
        }
        else if (!musicSrc.isPlaying && trackNumber == 1)
        {
            PlaySound("backgroundTrack2");
            trackNumber = 2;
            Debug.Log(trackNumber);
        }
        else if (!musicSrc.isPlaying && trackNumber == 2)
        {
            PlaySound("backgroundTrack3");
            trackNumber = 3;
            Debug.Log(trackNumber);
        }

    }

    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "backgroundTrack1":
                musicSrc.PlayOneShot(backgroundTrack1);
                break;
            case "backgroundTrack2":
                musicSrc.PlayOneShot(backgroundTrack2);
                break;
            case "backgroundTrack3":
                musicSrc.PlayOneShot(backgroundTrack3);
                break;
           
        }
    }
}
