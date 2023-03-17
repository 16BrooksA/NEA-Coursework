using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTest : MonoBehaviour
{
    public Decimal planet_mass = 5.9722e24m;
    public Decimal gravitational_constant = 6.6743e-11m;
    public float gravitational_force;
    public float distance;
    public Decimal dec_distance;
    public Vector3 angle;
    public Decimal ship_mass;
    public Vector3 gravity; 

    public GameObject Planet1;
    public GameObject spaceship;

    new Rigidbody rigidbody;

    void Start()
    {
        Planet1 = GameObject.Find("417 BigAl b");

        spaceship = GameObject.Find("Spaceship");
        Spaceship ship = spaceship.GetComponent<Spaceship>();
        ship_mass = Convert.ToDecimal(ship.get_spaceship_mass());

        /*float distance = Vector3.Distance(spaceship.transform.position, Planet1.transform.position);
        Decimal dec_distance = Convert.ToDecimal(distance);*/

        // Asigns the rigidbody to my object
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //6371146
        distance = Vector3.Distance(spaceship.transform.position, Planet1.transform.position) * 300000;
        dec_distance = Convert.ToDecimal(distance);

        angle = (spaceship.transform.position - Planet1.transform.position);
        //Decimal result = Decimal.Multiply(gravitational_constant, planet_mass);
        gravitational_force = (float)((gravitational_constant * planet_mass * ship_mass) / (dec_distance * dec_distance));

        gravity = gravitational_force * angle;

    }
}
