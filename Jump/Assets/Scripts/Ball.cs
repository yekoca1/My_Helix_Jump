using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameManager gm;
    public GameObject restartButton;
    public GameObject nextButton;
    public GameObject quitButton;
    public GameObject splashPrefab;
    public GameObject backVoice;
    public voiceController vc;  // hit sesi için
    public FinishSounder fs; // bitiş sesi
    public FailedSounder fail;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        vc = GameObject.FindObjectOfType<voiceController>();
        fs = GameObject.FindObjectOfType<FinishSounder>();
        fail = GameObject.FindObjectOfType<FailedSounder>();
        rb = GetComponent<Rigidbody>();
        restartButton.SetActive(false);
        nextButton.SetActive(false); 
        quitButton.SetActive(false);
        //gm.winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        vc.soundPlay();
        rb.velocity = Vector3.up*jumpForce; 
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0, -0.25f, 0) , transform.rotation); // prefab tam temas etmiyordu, alçalttık. Önemli!
        splash.transform.SetParent(other.gameObject.transform);

        string name = other.gameObject.GetComponent<MeshRenderer>().material.name;

        if(name == "unsafeMaterial (Instance)")
        {
            Time.timeScale = 0;
            fail.GetComponent<AudioSource>().Play();
            backVoice.GetComponent<AudioSource>().Stop();
            restartButton.SetActive(true);
            quitButton.SetActive(true);

        }

        else if(name == "Bitis (Instance)")
        {
            Time.timeScale = 0;
            fs.soundPlay();
            nextButton.SetActive(true);
            //gm.winText.gameObject.SetActive(true);
        }

    }

    //LEVELMANAGER SCRİPTİNİ ÇAĞIRACAĞIMIZ VE BU SCRİPTTE KULLANACAĞIMIZ FONKSİYONLAR !!!!

    
    /*private void SaveCurrentLevel()
    {
        int currentLevel = GetCurrentLevelIndex();
        levelManager.SaveLevel(currentLevel);
    }

    private int GetCurrentLevelIndex()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        return currentLevelIndex;
    }

    private void LoadSavedLevel()
    {
        if (levelManager != null) {
            int savedLevel = levelManager.LoadLevel();
            // Kaydedilen seviye varsa, o seviyeyi yükle, yoksa mevcut sahneyi yükle
            SceneManager.LoadScene(savedLevel != -1 ? savedLevel : GetCurrentLevelIndex());
        } else {
            Debug.LogError("Level Manager is not initialized");
        }
    }*/
}
