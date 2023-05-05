using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameManager gm;
    public GameObject restartButton;
    public GameObject nextButton;
    public GameObject splashPrefab;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        restartButton.SetActive(false);
        nextButton.SetActive(false); 
        //gm.winText.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = Vector3.up*jumpForce; 
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0, -0.25f, 0) , transform.rotation); // prefab tam temas etmiyordu, alçalttık. Önemli!
        splash.transform.SetParent(other.gameObject.transform);

        string name = other.gameObject.GetComponent<MeshRenderer>().material.name;

        if(name == "unsafeMaterial (Instance)")
        {
            Time.timeScale = 0;
            restartButton.SetActive(true);

        }

        else if(name == "Bitis (Instance)")
        {
            Time.timeScale = 0;
            nextButton.SetActive(true);
            //gm.winText.gameObject.SetActive(true);
        }

    }
}
