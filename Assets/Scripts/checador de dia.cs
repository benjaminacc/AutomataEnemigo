using System.Collections;
using System.Collections.Generic;
using BBSamples.PQSG;
using UnityEngine;

public class checadordedia : MonoBehaviour
{
    DoneDayNightCycle dayNightCycleChecker;
    // Update is called once per frame

    void Start()
    {
        dayNightCycleChecker = GetComponent<DoneDayNightCycle>();
        
    }
    void Update()
    {
        if(dayNightCycleChecker.isNight)
        {
            Debug.Log("Es de noche");
        }
        
    }
}
