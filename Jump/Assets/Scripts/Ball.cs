using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    private GameManager gm;

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
<<<<<<< Updated upstream
            gm.restartGame();
=======
            Time.timeScale = 0;
            fail.GetComponent<AudioSource>().Play();
            backVoice.GetComponent<AudioSource>().Stop();
            restartButton.SetActive(true);

>>>>>>> Stashed changes
        }

        else if(name == "Bitis (Instance)")
        {
<<<<<<< Updated upstream
            Debug.Log("Ball çalışıyor");
            gm.nextLevel();
=======
            Time.timeScale = 0;
            fs.soundPlay();
            nextButton.SetActive(true);
            //gm.winText.gameObject.SetActive(true);
>>>>>>> Stashed changes
        }

    }
}


