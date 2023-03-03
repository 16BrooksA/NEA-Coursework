using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTest : CelestialBody
{
    public Decimal planet_mass = 5.9722e24m;
    public Decimal ship_mass;
    public string Spaceship;
    public string BigAl_b;

    public GameObject spaceship;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("Spaceship");
        Spaceship ship = spaceship.GetComponent<Spaceship>();
        ship_mass = Convert.ToDecimal(ship.spaceship_mass);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        calculate_gravity(BigAl_b, planet_mass, Spaceship, ship_mass);
    }
}
