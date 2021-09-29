using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Modifica nr de vieti
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //Check for no lives left/end of game
        if(lives <=0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }

    //Modifica scor
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks<=0)
        {
            GameOver();
        }
    }

    //End Game
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    //Buton
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
