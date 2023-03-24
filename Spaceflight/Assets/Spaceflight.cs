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
    public float myangle;

    public ParticleSystem particles;

    public GameObject Planet1;

    public GameObject BAB;
    public GameObject fly;

    // Vector3 takes value for x, y, z axis
    public Vector3 moveDirection;
    public Vector3 rotateDirection;

    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
        myangle = Vector3.SignedAngle(BAB.transform.position, fly.transform.position, Vector3.up);

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        jumpMovement = Input.GetAxisRaw("Jump");
        yaw = Input.GetAxisRaw("Yaw");
        pitch = Input.GetAxisRaw("Pitch");
        roll = Input.GetAxisRaw("Roll");

        moveDirection = transform.forward * verticalMovement * 10000 + transform.right * horizontalMovement * 10000 + transform.up * jumpMovement * 10000;
        rotateDirection = transform.up * yaw * 100 + transform.right * pitch * 100 + transform.forward * roll * 100;

        Planet1 = GameObject.Find("BigAl_b");
        Planet planet = Planet1.GetComponent<Planet>();
        grav = planet.spaceship_gravity;

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
