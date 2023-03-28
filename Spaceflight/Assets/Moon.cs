using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : CelestialBody
{
    public Double planet_mass = 5.9722e24;
    public Double moon_mass = 7.347e22;
    public string BigAl_b = "BigAl_b";
    public string BigAl_b_i = "BigAl_b_i";
    public Vector3 grav;

    public Rigidbody moon_rigidbody;

    public GameObject Planet1;

    // Start is called before the first frame update
    void Start()
    {
        moon_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get_orbital_velocity("BigAl_b", planet_mass, "BigAl_b_i");

        //rigidbody.velocity = new Vector3(orbital_velocity, 0, 0);
        get_orbital_velocity("BigAl_b", planet_mass, "BigAl_b_i");

        get_x_velocity(orbital_velocity);
        get_z_velocity(orbital_velocity);

        moon_rigidbody.velocity = new Vector3(x_velocity * Time.deltaTime, 0, z_velocity * Time.deltaTime);

        /*Planet1 = GameObject.Find("BigAl_b");
        Planet planet = Planet1.GetComponent<Planet>();
        grav = planet.moon_gravity;*/

        //moon_rigidbody.AddForce(grav);
    }

    public Double get_moon_mass()
    {
        return moon_mass;
    }
}
