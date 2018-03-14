using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the Input of the Player
/// Moves the Character
/// Animate the Character
/// Handles Chrystal-Collision-Detection
/// </summary>
public class CharacterController : MonoBehaviour {

	/// <summary>
	/// The Speed of the Characters Movement
	/// </summary>
	public float speed = 3.0f;

	private Rigidbody rb;
	private Animator anim;
	private bool isFacingRight = true;
	private bool isGrounded = false;
	

	/// <summary>
	/// Start is called on the frame when a script is enabled just before 
	/// any of the Update methods is called the first time.
	/// 
	/// Initializes the Controller
	/// </summary>
	void Start () {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}
	
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// 
	///  - Only runs if game has started
	///  - Checks if Character is grounden. If not grounded he is not allowed to move and play the fall-animation
	///  - handles the input of the player
	///  - plays the animation of the character
	/// </summary>
	void Update () {
		//	Check if game has started

		//	Check if character falls

		//	Handle Players Input
		HandleInput();

		//	Movement
		Movement();	

		//	Set Animations
		Animate();
	}

	/// <summary>
	/// Checks if the player presses the Space-Bar.
	/// If so, the rotation of the player switches on 90°.
	/// </summary>
	private void HandleInput () {
		//	If Player presses 'Spacebar' the character should turn 90°
		if (Input.GetKeyDown("Space")) {
			isFacingRight = !isFacingRight;
		}
	}

	/// <summary>
	/// Walks / Pushes the character forwards, depedingung on the rotation.
	/// </summary>
	private void Movement () {
		//	@TODO
	}

	/// <summary>
	/// Sets the Paramters of the Animater-Controller
	/// </summary>
	private void Animate () {
		//	@TODO
	}

	/// <summary>
	/// Checks if the Character is grounded.
	/// Casts an Array downwards to check if Ground is below the player
	/// </summary>
	private void CheckGroundSate() {

	}

	/// <summary>
	/// Is called when the Collider other enters the trigger.
	/// 
	/// It's used to recognize the collision of Crystals for Scoring.
	/// </summary>
	/// <param name="collider">The Collider of the hit object</param>
	void OnTriggerEnter(Collider collider) {
		//	Is Collider a Crystal?

		//	Trigger Scoring
	}


}
