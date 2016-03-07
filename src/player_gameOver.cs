using UnityEngine;
using System.Collections;

public class player_gameOver : MonoBehaviour {

    public AudioClip death_sound;
    AudioSource audio;

    void Start ()
    {
        this.GetComponent<Animator>().Play("dolly_death");

        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(death_sound, 1.0f);
    }

}
