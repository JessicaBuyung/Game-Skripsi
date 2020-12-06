using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWin : MonoBehaviour {

    AudioManager audioManager;

    // Use this for initialization
    void Start()
    {
        audioManager = AudioManager.instance;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        audioManager.PlaySound("Win Sound");
    }
}
