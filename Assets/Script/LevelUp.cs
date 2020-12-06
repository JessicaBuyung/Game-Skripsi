using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour {

   private void OnTriggerEnter2D()
    {
        FindObjectOfType<Menu>().LoadNextScene();
    }
}
