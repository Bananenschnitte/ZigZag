using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Stores the Game Stats,
/// such as:
///  - current Score
///  - best Highscore
/// and has public methods such as hit Crystal
/// </summary>
public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

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
    public bool isGameStarted { get; private set; }

    /// <summary>
    /// Crystals the player has to score to reach the next difficulty --> increses the speed
    /// </summary>
    public int difficutlyIncreaseStep = 10;

    // -----------------------------------------------------------
        
	private int currentScore = 0;
	private int highScore = 0;
    private AudioSource music;
    private AudioSource sfx_crystal;
    private AudioSource sfx_gameOver;
    private LevelCreation levelCreation;
    private int nextDifficutly = 10;

    /// <summary>
    /// Is called when the script instance is being loaded.
    /// Its used for singleton
    /// </summary>
    private void Awake () {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource a in audioSources) {
            
            Debug.Log("AudioSource: " + a.clip.name);
            if (a.clip.name.Contains("coin")) {
                sfx_crystal = a;
            }

            if (a.clip.name.Contains("music")) {
                music = a;
            }

            if (a.clip.name.Contains("over")) {
                sfx_gameOver = a;
            }
        }

        levelCreation = FindObjectOfType<LevelCreation>();
        nextDifficutly = difficutlyIncreaseStep;
    }

    /// <summary>
    /// Starts the game.
    /// 
    /// Sets Variable 'isGameStarted' to true.
    /// Starts playing the background-Music
    /// </summary>
    public void StartGame () {
        isGameStarted = true;
		StartPlayMusic();

        
        
        levelCreation.StartBuilding();
	}

	/// <summary>
	/// Start playing Music (if not already)
	/// </summary>
	private void StartPlayMusic() {
        music.Play();
	}

	/// <summary>
	/// Should be called when Player Scores by hitting a Crystal.
	/// Counts the current Score +1, and updates the Score-Texts
	/// </summary>
	public void Score () {
		currentScore++;
		text_currentScore.text = currentScore.ToString();

		if (currentScore > highScore) {

            //  Display the new Highscore
			text_highScore = text_currentScore;

            //  Save the Highscore
            PlayerPrefs.SetInt("Highscore", currentScore);

            //  Play scroing Sound
            sfx_crystal.Play();

            //  Increase Speed of Player if player hits the next score-level
            if (currentScore >= nextDifficutly) {
                nextDifficutly += difficutlyIncreaseStep;
                PlayerController.Instance.IncreaseSpeed();
            }

			// may trigger special partivle effect to indicate that the highscore is reached
			// or change the color of the scoring particel effect
		}
		
	}

    /// <summary>
    /// Restarts the Game
    /// </summary>
    public void RestartGame () {
        //  Set Game on not started
        isGameStarted = false;

        //  Reload the Scene
        SceneManager.LoadScene(0);        

        //  Play Death Sound
        sfx_gameOver.Play();        
    }

    /// <summary>
    /// Gets the current Highscore
    /// </summary>
    /// <returns>The Current Highscore</returns>
    public int GetHighScore () {
        return PlayerPrefs.GetInt("Highscore");
    }
}
