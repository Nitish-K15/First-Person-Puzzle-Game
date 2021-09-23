using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleColor : MonoBehaviour
{
    private Renderer Rmaterial;
    Color[] colour = { Color.red, Color.blue, Color.yellow, Color.green, Color.black };
    void Start()
    {
        Rmaterial = GetComponent<Renderer>();
        int num = Random.Range(0, 4);
        Rmaterial.material.color = colour[num];
    }
}
