﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameEnd gameEnd;
	void OnTriggerEnter2D(Collider2D col)
    {
        gameEnd.CompleteLevel();
    }
}
