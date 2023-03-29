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

    public ParticleSystem particles;

    public GameObject Planet1;

    public GameObject solar;
    public GameObject fly;
    public float myangle;
    public Vector3 toPointA;
    public Vector3 toPointB;

    // Vector3 takes value for x, y, z axis
    public Vector3 moveDirection;
    public Vector3 rotateDirection;

    public Rigidbody spaceship_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        spaceship_rigidbody = GetComponent<Rigidbody>();

        solar = GameObject.Find("Sun");

        fly = GameObject.Find("Spaceship");
    }

    // Update is called once per frame
    void Update()
    {
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
        myangle = Vector3.Angle(solar.transform.position, solar.transform.position - fly.transform.position);

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        jumpMovement = Input.GetAxisRaw("Jump");
        yaw = Input.GetAxisRaw("Yaw");
        pitch = Input.GetAxisRaw("Pitch");
        roll = Input.GetAxisRaw("Roll");

        moveDirection = transform.forward * verticalMovement * 10000 + transform.right * horizontalMovement * 10000 + transform.up * jumpMovement * 10000;
        rotateDirection = transform.up * yaw * 100 + transform.right * pitch * 100 + transform.forward * roll * 100;

        Planet1 = GameObject.Find("Earth");
        Planet planet = Planet1.GetComponent<Planet>();
        grav = planet.spaceship_gravity;

        spaceship_rigidbody.AddForce(moveDirection);
        spaceship_rigidbody.AddTorque(rotateDirection);

        spaceship_rigidbody.AddForce(grav);

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
