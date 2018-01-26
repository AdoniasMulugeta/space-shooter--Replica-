using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	public Text scoreText;
	public GameObject gameOverText;
	public bool isGameover;
	
	void Start(){
		updateScore(0);
		hideGameOver();
	}
	void updateScore(int score){
		showScore("Score:"+score);
	}

	
	void showScore(string score){
		scoreText.text = score;
	}
	void showGameOver(){
		gameOverText.SetActive(true);
	}
	void hideGameOver(){
		gameOverText.SetActive(false);
	}





	void OnEnable(){
		GameManager.eventScoreUpdate += updateScore;
		GameManager.eventGameOver += showGameOver;
	}
	void OnDisable(){
		GameManager.eventScoreUpdate -= updateScore;
		GameManager.eventGameOver -= showGameOver;
	}
}
