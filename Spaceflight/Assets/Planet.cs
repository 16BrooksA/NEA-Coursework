using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float mass;

    Rigidbody rigidbody;

    void Start()
    {
        // Asigns the rigidbody to my object
        rigidbody = GetComponent<Rigidbody>();
    }
}
