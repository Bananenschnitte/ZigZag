using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Stores the Game Stats,
/// such as:
///  - current Score
///  - best Highscore
/// and has public methods such as hit Crystal
/// 
/// </summary>
public class GameManager : MonoBehaviour {

	/// <summary>
	/// The UI-Text to show the current Score
	/// </summary>
	public Text text_currentScore;

	/// <summary>
	/// The UI-Text for the best highscore
	/// </summary>
	public Text text_highScore;

	/// <summary>
	/// Indicates if the Game has started due to the Player
	/// </summary>
	public bool isGameStarted = false;


	private int currentScore = 0;
	private int highScore = 0;

	/// <summary>
	/// Starts the game.
	/// 
	/// Sets Variable 'isGameStarted' to true.
	/// Starts playing the background-Music
	/// </summary>
	public void StartGame() {
		isGameStarted = true;

		StartPlayMusic();
	}

	/// <summary>
	/// Start playing Music (if not already)
	/// </summary>
	private void StartPlayMusic() {
		// @TODO
	}

	/// <summary>
	/// Should be called when Player Scores by hitting a Crystal.
	/// Counts the current Score +1, and updates the Score-Texts
	/// </summary>
	public void score() {
		currentScore++;
		text_currentScore.text = currentScore.ToString();

		if (currentScore > highScore) {
			text_highScore = text_currentScore;
			// may trigger special partivle effect to indicate that the highscore is reached
			// or change the color of the scoring particel effect
		}
		
	}
}
