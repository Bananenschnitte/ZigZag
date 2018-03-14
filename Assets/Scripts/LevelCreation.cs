using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Expands continously the Level
/// </summary>
public class LevelCreation : MonoBehaviour {

	/// <summary>
	/// Template of the Block used to create the Level
	/// </summary>
	public GameObject templatePathBrick;

	/// <summary>
	/// The Rate how many Path-Parts are Created in a secons. (Lower value is faster creation)
	/// </summary>
	public float creationRate = 0.5f;

	/// <summary>
	/// The last and starting Position of creating the next Block
	/// </summary>
	public Vector3 lastPosition;

	/// <summary>
	/// Frequency the Cristal will spawn with the Blocks. 
	/// (e.g: 5 means every 5th block has a Crystal)
	/// </summary>
	public int chrystalFrequency = 5;

	// Use this for initialization
	void Start () {
		if (templatePathBrick == null) {
			Debug.LogError("[LevelCreation] No Prefab set to 'templatePathBrick'");
		}

		if (lastPosition == null) {
			Debug.LogError("[LevelCreation] No 'lastPosition' is set");
		}
	}

	/// <summary>
	/// Creates a new Part of the Path using the template (Prefab)
	/// </summary>
	private void CreateNewPathPart () {

	}
}
