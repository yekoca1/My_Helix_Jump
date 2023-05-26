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
   //public TextMeshProUGUI winText;
   public string nextLevelName = "Level2";
   //public static GameManager instance;
   public LevelManager levelManager;
    void Start()
    {    
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.SaveCurrentScene();
        scoreText = GameObject.FindObjectOfType<TextMeshProUGUI>();
        //winText = GameObject.FindObjectOfType<TextMeshProUGUI>();
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
        levelManager.SaveCurrentScene(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void nextLevel()
    {
        levelManager.SaveCurrentScene();
        SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1;
    }

    public void quit()
    {
        levelManager.SaveCurrentScene(); 
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
