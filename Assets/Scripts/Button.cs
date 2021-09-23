using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject[] solvers = new GameObject[5];
    private Renderer rend;
    private bool inRange;
    public MovingPlatform platform;
    private bool canMove;
    public Text Displaytext;
    private void Start()
    {
        rend = GetComponentInParent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    private void Update()
    {
        if(inRange)
        {
            Displaytext.gameObject.SetActive(true);
        }
        else
        {
            Displaytext.gameObject.SetActive(false);
        }
       for(int i =0;i<5;i++)
        {
            if (solvers[i].GetComponent<SolverColor>().isCorrect == true)
                canMove = true;
            else
                canMove = false;
        }

       if(canMove)
        {
            rend.material.color = Color.green;
        }
       else
        {
            rend.material.color = Color.red;
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            platform. enabled = true;
        }

    }
}
