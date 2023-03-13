using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : CelestialBody
{
    public Decimal planet_mass = 5.9722e24m;
    public string BigAl_b = "BigAl_b";
    public string BigAl_b_i = "BigAl_b_i";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        get_orbital_velocity("BigAl_b", planet_mass, "BigAl_b_i");
    }
}
