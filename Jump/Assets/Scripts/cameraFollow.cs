using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;
    public float smoothness;
    void Start()
    {
        offset = transform.position - ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = Vector3.Lerp(transform.position, offset + ball.position, smoothness); // iki noktanın arasını doldurmaya yani geçiş efekti yapmaya yarar.
        transform.position = newpos;
    }
}
