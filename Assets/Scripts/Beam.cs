using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public Transform screamPoint;
    public GameObject beamPrefab;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Scream();

        }
    }
    void Scream ()
    {   
            Instantiate(beamPrefab, screamPoint.position, screamPoint.rotation);        
    }
}
