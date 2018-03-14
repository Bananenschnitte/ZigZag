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
	public float speed = 2.0f;
    public Transform rayStart;
    public GameObject CrystalEffect;

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
	private void Start() {
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
	private void Update() {

        //	Check if game has started
        if (GameManager.Instance.isGameStarted) {            

            //	Check if character is grounded / has to fall
            GetIsGrounded();

            //	Handle Players Input
            HandleInput();

            //  Check if Character dies
            HandleDeath();

            //	Set Animations
            Animate();
        } else {
            StartGame();
        }
	}

    private void FixedUpdate() {
        if (GameManager.Instance.isGameStarted) {
            Move();
        }
    }

    /// <summary>
    /// Checks if the player presses the Space-Bar.
    /// If so, the rotation of the player switches on 90°.
    /// </summary>
    private void HandleInput() {
		if (Input.GetKeyDown(KeyCode.Space)) {
            Switch();
		}
	}

	/// <summary>
	/// Walks / Pushes the character forwards, depedingung on the rotation.
	/// </summary>
	private void Move() {        
        rb.transform.position = transform.position + transform.forward * speed * Time.deltaTime;        
	}

    /// <summary>
    /// Swtiches the Direction 
    /// </summary>
    private void Switch() {
        isFacingRight = !isFacingRight;

        if (isFacingRight) {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

	/// <summary>
	/// Sets the Paramters of the Animater-Controller
	/// </summary>
	private void Animate() {
        anim.SetBool("isGrounded", isGrounded);
	}

	/// <summary>
	/// Checks if the Character is grounded.
	/// Casts an Array downwards to check if Ground is below the player
	/// </summary>
	private void GetIsGrounded() {
        RaycastHit hit;
        Physics.Raycast(rayStart.position, -transform.up, out hit, 3);        
	}

	/// <summary>
	/// Is called when the Collider other enters the trigger.
	/// 
	/// It's used to recognize the collision of Crystals for Scoring.
	/// </summary>
	/// <param name="other">The Collider of the hit object</param>
	public void OnTriggerEnter(Collider other) {

		//	Is Collider a Crystal?
        if (other.tag == "Crystal") {
            
    		//  Increase the Scoring
            GameManager.Instance.Score();

            //  Trigger Crystal Effect
            GameObject g = Instantiate(CrystalEffect, transform.position, Quaternion.identity);
            Destroy(g, 2);

            //  Destroy the Crystal (make it disappear)
            Destroy(other.gameObject, 0.1f);
        }

	}

	/// <summary>
	/// Handles when the Player dies and what happens after Death
	/// </summary>
	private void HandleDeath() {

		//  Check if Players y-Position is lower 2 --> dead
        if (transform.position.y < -2) {

		    //  Trigger Death-Method of GameManager --> Reload Scene
            GameManager.Instance.RestartGame();
        }

	}

    private void StartGame() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            GameManager.Instance.StartGame();
            anim.SetTrigger("gameStarted");
        }
    }


}
