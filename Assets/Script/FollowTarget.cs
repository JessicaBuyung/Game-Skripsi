using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    // what we are following
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;

   
   private void FixedUpdte()
    {
        Follow();
    }
	
    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
  }
}
