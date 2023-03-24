using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    //public Decimal big_mass;
    //public Decimal small_mass;
    public Double gravitational_constant = 6.6743e-11;
    public float gravitational_force;
    public float distance;
    public Double dec_distance;
    public Vector3 angle;
    public float x_local_angle;
    public float x_radian_angle;
    public float z_local_angle;
    public float z_radian_angle;
    public Vector3 gravity;
    public float orbital_velocity;
    public float x_velocity;
    public float z_velocity;
    //public string big_body;
    //public string small_body;

    public GameObject body1;
    public GameObject body2;

    public Vector3 calculate_gravity(string big_body, Double big_mass, string small_body, Double small_mass)
    {
        body1 = GameObject.Find(big_body);

        body2 = GameObject.Find(small_body);
        
        //6371146 = radius of earth (use this to scale sizes of planets)
        distance = Vector3.Distance(body2.transform.position, body1.transform.position) * 300000;
        dec_distance = Convert.ToDouble(distance);

        angle = (body2.transform.position - body1.transform.position);
        gravitational_force = -((float)((gravitational_constant * big_mass * small_mass) / (dec_distance * dec_distance)));

        gravity = gravitational_force * angle;

        return gravity;
    }

    public float get_x_velocity(string big_body, Double big_mass, string small_body)
    {
        body1 = GameObject.Find(big_body);

        body2 = GameObject.Find(small_body);

        distance = Vector3.Distance(body2.transform.position, body1.transform.position) * 300000;
        dec_distance = Convert.ToDouble(distance);

        orbital_velocity = Mathf.Sqrt((float)((gravitational_constant * big_mass) / (dec_distance)));

        angle = (body2.transform.position - body1.transform.position);

        x_velocity = orbital_velocity * Mathf.Cos(angle);

        return x_velocity;
    }

    public float get_z_velocity(string big_body, Double big_mass, string small_body)
    {
        body1 = GameObject.Find(big_body);

        body2 = GameObject.Find(small_body);

        distance = Vector3.Distance(body2.transform.position, body1.transform.position) * 30000000;
        dec_distance = Convert.ToDouble(distance);

        orbital_velocity = Mathf.Sqrt((float)((gravitational_constant * big_mass) / (dec_distance)));

        angle = (body2.transform.position - body1.transform.position);

        z_velocity = orbital_velocity * Mathf.Sin(angle);

        return z_velocity;
    }

    public float get_x_velocity(float orbital_velocity)
    {
        x_local_angle = Vector3.Angle(body1.transform.position, body2.transform.position);

        x_radian_angle = x_local_angle * (float)(Math.PI / 180);

        x_velocity = orbital_velocity * Mathf.Cos(x_radian_angle);

        return x_velocity;
    }

    public float get_z_velocity(float orbital_velocity)
    {
        z_local_angle = Vector3.SignedAngle(body1.transform.position, body2.transform.position, Vector3.up);

        z_radian_angle = z_local_angle * (float)(Math.PI / 180);

        z_velocity = orbital_velocity * Mathf.Sin(-z_radian_angle);

        return z_velocity;
    }
}
