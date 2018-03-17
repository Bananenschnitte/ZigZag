using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Expands continously the Level
/// 
/// @IDEA: Only creaete 1 Fix block, and on start create the first X-Blocks and only after them create it frequently
/// @IDEA: Change the Chrystal-Frequency to a percentage change to spawn with a block. so it would be more random
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
	/// Frequency the Cristal will spawn with the Blocks. 
	/// (e.g: 5 means every 5th block has a Crystal)
	/// </summary>
	public int chrystalFrequency = 5;

    /// <summary>
    /// Amount of Cubes, created on Start for the Level
    /// </summary>
    public int initialCreatedLevelParts = 30;
    
    private float offset = 0.7f;
    private int roadCount = 0;
    private Vector3 lastPosition;

    private void Start () {
		if (templatePathBrick == null) {
			Debug.LogError("[LevelCreation] No Prefab set to 'templatePathBrick'");
		}

		if (lastPosition == null) {
			Debug.LogError("[LevelCreation] No 'lastPosition' is set");
		}

        //  Create Initial Path
        CreateInitialLevel();

        StartBuilding();
    }
    
    public void StartBuilding () {
        InvokeRepeating("CreateNewPathPart", 1f, creationRate);        
    }

    /// <summary>
    /// Creates a new Part of the Path using the template (Prefab)
    /// </summary>
    private void CreateNewPathPart () {

        //  Define ranomly the next block right or left of the last position
        if (roadCount > 0) {
            if (Random.value > 0.5) {
                lastPosition.x += offset;
                lastPosition.z += offset;
            } else {
                lastPosition.x -= offset;
                lastPosition.z += offset;
            }
        }
        
        //  Create the Object
        GameObject go = Instantiate(templatePathBrick, lastPosition, Quaternion.Euler(0, 45, 0));
        roadCount++;

        //  Active Crystal on every 5. Roadpart
        if (roadCount % 5 == 0) {
            go.transform.GetChild(0).gameObject.SetActive(true);
        }
	}

    /// <summary>
    /// Creates the Initial-Level. (As far as the player can see). 
    /// After this the Level growth 
    /// </summary>
    public void CreateInitialLevel () {
        lastPosition = new Vector3(0.7f, 0, 0.7f);
        roadCount = 0;

        int i;
        for (i = 0; i < initialCreatedLevelParts; i++) {
            CreateNewPathPart();
        }
    }
}
