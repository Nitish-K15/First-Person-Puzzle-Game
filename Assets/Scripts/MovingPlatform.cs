using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform start; 
    public Transform end;   
    public float t;         
    public float speed = 1;   
    public float speedMultiplier;
    void Start()
    {
        this.enabled = false;
        speedMultiplier = speed / Vector3.Distance(start.position, end.position);
    }
    void FixedUpdate()
    {
        t = Mathf.Clamp(t + Time.deltaTime * speedMultiplier, 0, 1);    
            speedMultiplier = speed / Vector3.Distance(start.position, end.position);
            t = t + Time.deltaTime;
            float cosT = (Mathf.Cos(t * Mathf.PI * speedMultiplier) + 1) / 2;
            transform.position = start.position * (1 - cosT) + end.position * cosT;
    }
}
