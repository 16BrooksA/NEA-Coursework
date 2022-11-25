using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceflight : MonoBehaviour
{
    public float horizontalMovement;
    public float verticalMovement;
    public float jumpMovement;
    public float horizontalRotation;
    public float verticalRotation;

    // Vector3 takes value for x, y, z axis
    public Vector3 moveDirection;
    public Vector3 rotateDirection;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Asigns the rigidbody to my object
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        jumpMovement = Input.GetAxisRaw("Jump");
        horizontalRotation = Input.GetAxisRaw("Horizontal2");
        verticalRotation = Input.GetAxisRaw("Vertical2");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement + transform.up * jumpMovement;
        rotateDirection = transform.up * horizontalRotation + transform.right * verticalRotation;
    }
    
    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        rigidbody.AddForce(moveDirection);
        rigidbody.AddTorque(rotateDirection);
    }
}
