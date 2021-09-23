using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SolverColor : MonoBehaviour
{
    Color[] colour = { Color.red, Color.blue, Color.yellow, Color.green, Color.black };
    int i = 0;
    private bool inRange = false;
    public bool isCorrect;
    public Renderer Puzzler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (i < colour.Length)
            {
                GetComponentInParent<Renderer>().material.color = colour[i];
                i++;

            }
            if(i == 5)
            {
                i = 0;
            }
        }
        if(Puzzler.material.color == GetComponentInParent<Renderer>().material.color)
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
    } 
}
