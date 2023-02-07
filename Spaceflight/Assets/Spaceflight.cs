using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceflight : MonoBehaviour
{
    public float horizontalMovement;
    public float verticalMovement;
    public float jumpMovement;
    public float yaw;
    public float pitch;
    public float roll;
    public Vector3 grav;
    public Vector3 x;

    public ParticleSystem particles;

    public GameObject Planet1;

    // Vector3 takes value for x, y, z axis
    public Vector3 moveDirection;
    public Vector3 rotateDirection;

    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        /*Planet1 = GameObject.Find("Planet1");
        Planet planet = Planet1.GetComponent<Planet>();
        grav = planet.gravity;*/

        // Asigns the rigidbody to my object
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        jumpMovement = Input.GetAxisRaw("Jump");
        yaw = Input.GetAxisRaw("Yaw");
        pitch = Input.GetAxisRaw("Pitch");
        roll = Input.GetAxisRaw("Roll");

        Planet1 = GameObject.Find("Planet1");
        Planet planet = Planet1.GetComponent<Planet>();
        grav = planet.gravity;

        x = transform.forward;

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement + transform.up * jumpMovement;
        rotateDirection = transform.up * yaw + transform.right * pitch + transform.forward * roll;

        /*if(verticalMovement > 0)
        {
            particles.Play();
            print("1");
        }
        else if(Input.GetKeyDown("m"))
        {
            particles.Stop();
            print("0");
        }*/
    }
    
    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        rigidbody.AddForce(moveDirection);
        rigidbody.AddTorque(rotateDirection);

        rigidbody.AddForce(grav);

        /*if(verticalMovement < 0 || verticalMovement > 0)
        {
            particles.Play();
            print("1");
        }
        else if(verticalMovement == 0)
        {
            particles.Stop();
            print("0");
        }*/
    }
}
