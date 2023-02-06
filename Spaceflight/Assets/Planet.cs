using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Decimal planet_mass = 5.9722e24m;
    public Decimal gravitational_constant = 6.6743e-11m;
    public float gravitational_force;
    public Decimal distance;
    public Decimal ship_mass;

    Rigidbody rigidbody;

    void Start()
    {
        GameObject Planet1 = GameObject.Find("Planet1");

        GameObject spaceship = GameObject.Find("Spaceship");
        Spaceship ship = spaceship.GetComponent<Spaceship>();
        Decimal ship_mass = Convert.ToDecimal(ship.spaceship_mass);

        Decimal distance = Convert.ToDecimal(Vector3.Distance(spaceship.transform.position, Planet1.transform.position));

        // Asigns the rigidbody to my object
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Decimal result = Decimal.Multiply(gravitational_constant, planet_mass);
        gravitational_force = (float)((gravitational_constant * planet_mass * ship_mass) / (distance * distance));

    }
}
