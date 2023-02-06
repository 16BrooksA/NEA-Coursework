using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Decimal planet_mass = 5.9722e24m;
    public Decimal gravitational_constant = 6.6743e-11m;
    public float gravitational_force;
    public float distance;
    public Decimal dec_distance;
    public Decimal ship_mass;

    public GameObject Planet1;
    public GameObject spaceship;

    Rigidbody rigidbody;

    void Start()
    {
        Planet1 = GameObject.Find("Planet1");

        spaceship = GameObject.Find("Spaceship");
        Spaceship ship = spaceship.GetComponent<Spaceship>();
        ship_mass = Convert.ToDecimal(ship.spaceship_mass);

        /*float distance = Vector3.Distance(spaceship.transform.position, Planet1.transform.position);
        Decimal dec_distance = Convert.ToDecimal(distance);*/

        // Asigns the rigidbody to my object
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(spaceship.transform.position, Planet1.transform.position);
        dec_distance = Convert.ToDecimal(distance);

        //Decimal result = Decimal.Multiply(gravitational_constant, planet_mass);
        gravitational_force = (float)((gravitational_constant * planet_mass * ship_mass) / (dec_distance * dec_distance));

    }
}
