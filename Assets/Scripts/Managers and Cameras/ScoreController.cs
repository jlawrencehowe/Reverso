using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

    /// <summary>
    /// Programmer: Jacob Howe
    /// 
    /// Changes score on canvas
    /// </summary>
	public float playerScore;
    public Text score;
	

    //Called by ???
	public void UpdatePlayerScore(float scoreIncrease){

		playerScore += scoreIncrease;

		score.text = "Score: " + string.Format("{0:00000}", playerScore);

	}
}
