using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : CelestialBody
{
    //1.989e30
    public Double sun_mass = 1.989e27;
    public Double ship_mass;
    public Vector3 sun_spaceship_gravity;

    public GameObject spaceship;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("Spaceship");
        Spaceship ship = spaceship.GetComponent<Spaceship>();
        ship_mass = Convert.ToDouble(ship.get_spaceship_mass());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sun_spaceship_gravity = calculate_gravity("Sun", sun_mass, "Spaceship", ship_mass);
    }

    public Double get_star_mass()
    {
        return sun_mass;
    }
}
