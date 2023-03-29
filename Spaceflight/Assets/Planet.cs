using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : CelestialBody
{
    public Double sun_mass = 1.989e30;
    public Double planet_mass = 5.9722e24;
    public Double ship_mass;
    public Double moon_mass;
    public string Sun = "Sun";
    public string Spaceship = "Spaceship";
    public string Earth = "Earth";
    public Vector3 spaceship_gravity;
    public Vector3 moon_gravity;

    public float earth_sun_orbital_velocity;
    public float earth_sun_x_velocity;
    public float earth_sun_z_velocity;

    public GameObject spaceship;
    public GameObject moon;
    public GameObject sun;

    public Rigidbody earth_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("Spaceship");
        Spaceship ship = spaceship.GetComponent<Spaceship>();
        ship_mass = Convert.ToDouble(ship.get_spaceship_mass());

        sun = GameObject.Find("Sun");

        //moon = GameObject.Find("Luna");
        //Moon Luna = moon.GetComponent<Moon>();
        //moon_mass = Luna.get_moon_mass();

        earth_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        earth_sun_orbital_velocity = get_orbital_velocity("Sun", sun_mass, "Earth");
        earth_sun_x_velocity = get_x_velocity("Sun", earth_sun_orbital_velocity, "Earth", "SunOrigin");
        earth_sun_z_velocity = get_z_velocity("Sun", earth_sun_orbital_velocity, "Earth", "SunOrigin");

        spaceship_gravity = calculate_gravity("Earth", planet_mass, "Spaceship", ship_mass);

        //moon_gravity = calculate_gravity("Earth", planet_mass, "Luna", moon_mass);

        earth_rigidbody.velocity = new Vector3(earth_sun_x_velocity * Time.deltaTime, 0, earth_sun_z_velocity * Time.deltaTime);
    }
}
