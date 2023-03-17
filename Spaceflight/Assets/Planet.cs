using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : CelestialBody
{
    public Double planet_mass = 5.9722e24;
    public Double ship_mass;
    public Double moon_mass;
    public string Spaceship = "Spaceship";
    public string BigAl_b = "BigAl_b";
    public Vector3 spaceship_gravity;
    public Vector3 moon_gravity;

    public GameObject spaceship;
    public GameObject moon;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("Spaceship");
        Spaceship ship = spaceship.GetComponent<Spaceship>();
        ship_mass = Convert.ToDouble(ship.get_spaceship_mass());

        moon = GameObject.Find("BigAl_b_i");
        Moon BigAl_b_i = moon.GetComponent<Moon>();
        moon_mass = BigAl_b_i.get_moon_mass();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spaceship_gravity = calculate_gravity("BigAl_b", planet_mass, "Spaceship", ship_mass);

        moon_gravity = calculate_gravity("BigAl_b", planet_mass, "BigAl_b_i", moon_mass);
    }
}
