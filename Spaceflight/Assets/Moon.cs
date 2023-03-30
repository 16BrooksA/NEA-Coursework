using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : CelestialBody
{
    public Double sun_mass;
    public Double planet_mass = 5.9722e24;
    public Double moon_mass = 7.347e22;
    public Double ship_mass;
    public string Sun = "Sun";
    public string Earth = "Earth";
    public string Luna = "Luna";
    public Vector3 grav;
    public Vector3 moon_spaceship_gravity;

    public float earth_sun_orbital_velocity;
    public float earth_sun_x_velocity;
    public float earth_sun_z_velocity;
    public float moon_earth_orbital_velocity;
    public float moon_earth_x_velocity;
    public float moon_earth_z_velocity;

    public float total_moon_x_velocity;
    public float total_moon_z_velocity;

    public Rigidbody moon_rigidbody;

    public GameObject sun;
    public GameObject Planet1;
    public GameObject spaceship;

    // Start is called before the first frame update
    void Start()
    {
        moon_rigidbody = GetComponent<Rigidbody>();

        spaceship = GameObject.Find("Spaceship");
        Spaceship ship = spaceship.GetComponent<Spaceship>();
        ship_mass = Convert.ToDouble(ship.get_spaceship_mass());

        sun = GameObject.Find("Sun");
        Star solar = sun.GetComponent<Star>();
        sun_mass = solar.get_star_mass();

        Planet1 = GameObject.Find("Earth");
        Planet earth = Planet1.GetComponent<Planet>();
        planet_mass = earth.get_planet_mass();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get_orbital_velocity("BigAl_b", planet_mass, "BigAl_b_i");

        //rigidbody.velocity = new Vector3(orbital_velocity, 0, 0);



        earth_sun_orbital_velocity = get_orbital_velocity("Sun", sun_mass, "Earth");

        earth_sun_x_velocity = get_x_velocity("Sun", earth_sun_orbital_velocity, "Earth", "SunOrigin");
        earth_sun_z_velocity = get_z_velocity("Sun", earth_sun_orbital_velocity, "Earth", "SunOrigin");

        moon_earth_orbital_velocity = get_orbital_velocity("Earth", planet_mass, "Luna");

        moon_earth_x_velocity = get_x_velocity("Earth", moon_earth_orbital_velocity, "Luna", "EarthOrigin");
        moon_earth_z_velocity = get_z_velocity("Earth", moon_earth_orbital_velocity, "Luna", "EarthOrigin");

        total_moon_x_velocity = moon_earth_x_velocity + earth_sun_x_velocity;
        total_moon_z_velocity = moon_earth_z_velocity + earth_sun_z_velocity;

        moon_rigidbody.velocity = new Vector3(total_moon_x_velocity, 0, total_moon_z_velocity);


        moon_spaceship_gravity = calculate_gravity("Moon", moon_mass, "Spaceship", ship_mass);



        //Planet1 = GameObject.Find("Earth");
        //Planet planet = Planet1.GetComponent<Planet>();
        //grav = planet.moon_gravity;

        //moon_rigidbody.AddForce(grav);


    }

    public Double get_moon_mass()
    {
        return moon_mass;
    }
}
