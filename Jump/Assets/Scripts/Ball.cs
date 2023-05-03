using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    private GameManager gm;

    public GameObject splashPrefab;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
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
            gm.restartGame();
        }

        else if(name == "Bitis(Instance)")
        {
            Debug.Log("NextLevel");
        }

    }
}
