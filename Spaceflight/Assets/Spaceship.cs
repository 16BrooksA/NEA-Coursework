using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    void Start()
    {
        GameObject Planet1 = GameObject.Find("Planet1");
        Planet planet = Planet1.GetComponent<Planet>();
        float planet_mass = planet.mass;

        if(planet_mass == 100)
        {
            print("yes");
        }
        else
        {
            print("no");
        }
    }
    
}
