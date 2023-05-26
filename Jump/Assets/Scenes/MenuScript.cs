using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public LevelManager lm;

    private void Start()
    {
        //lm = FindObjectOfType<LevelManager>();
    }

    public void play()
    {
        //lm.SaveCurrentScene(); // Mevcut sahneyi kaydet
        SceneManager.LoadScene(1); // Yeni sahneyi yükle
    }

    public void quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

