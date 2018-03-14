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

	public Text text_currentScore;
	public Text text_highScore;

	public bool isGameStarted = false;


	private int currentScore = 0;
	private int highScore = 0;

	/// <summary>
	/// Starts the game.
	/// 
	/// Sets Variable 'isGameStarted' to true
	/// </summary>
	public void StartGame() {
		isGameStarted = true;
	}

	/// <summary>
	/// Start playing Music (if not already)
	/// </summary>
	private void StartPlayMusic() {

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
			// may trigger special partivle effect,
			// or change the color of the scoring particel effect
		}
		
	}
}
