using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    //public Decimal big_mass;
    //public Decimal small_mass;
    public Decimal gravitational_constant = 6.6743e-11m;
    public float gravitational_force;
    public float distance;
    public Decimal dec_distance;
    public Vector3 angle;
    public Vector3 gravity;
    //public string big_body;
    //public string small_body;

    public GameObject body1;
    public GameObject body2;

    public Vector3 calculate_gravity(string big_body, Decimal big_mass, string small_body, Decimal small_mass)
    {
        body1 = GameObject.Find(big_body);

        body2 = GameObject.Find(small_body);
        
        //6371146 = radius of earth (use this to scale sizes of planets)
        distance = Vector3.Distance(body2.transform.position, body1.transform.position) * 300000;
        dec_distance = Convert.ToDecimal(distance);

        angle = (body2.transform.position - body1.transform.position);
        gravitational_force = (float)((gravitational_constant * big_mass * small_mass) / (dec_distance * dec_distance));

        gravity = gravitational_force * angle;

        return gravity;
    }
}
