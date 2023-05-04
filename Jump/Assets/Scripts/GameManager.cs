using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;
using TMPro;




public class GameManager : MonoBehaviour
{
   private int score = 0;
   public TextMeshProUGUI scoreText;
   public string nextLevelName;
    void Start()
    {
        scoreText = GameObject.FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    public void GameScore(int processScore)
    {
        score += processScore;
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
            Debug.Log("Game Manager çalışıyor");
            SceneManager.LoadScene(nextLevelName);
    }
}

