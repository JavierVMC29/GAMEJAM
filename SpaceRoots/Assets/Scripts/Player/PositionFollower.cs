using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollower : MonoBehaviour
{
    private Transform targetTransform;
    public Vector3 offset;

    private void Start()
    {
        targetTransform = FindObjectOfType<Camera>().transform;
    }

    void Update()
    {
        transform.position = targetTransform.position + offset;
    }
}
