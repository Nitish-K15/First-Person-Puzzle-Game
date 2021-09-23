using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform cameraposition;

    private void Update()
    {
        transform.position = cameraposition.position;
    }
}

