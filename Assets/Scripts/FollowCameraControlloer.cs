using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple Camera-Follow Script that sticks to an Object with the inital offset.
/// </summary>
public class FollowCameraControlloer : MonoBehaviour {

    /// <summary>
    /// The Gameobject to follow
    /// </summary>
    public Transform target;

    /// <summary>
    /// The Offset to keep to the target
    /// </summary>
    private Vector3 offset;
	
	public void Awake() {
        //  save Offset
        offset = transform.position - target.position;
	}
	
	private void LateUpdate() {
        transform.position = target.position + offset;
	}
}
