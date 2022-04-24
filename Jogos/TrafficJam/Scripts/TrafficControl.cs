using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficControl : MonoBehaviour
{
    public TrafficSensor [] sensors;   

    void Update()
    {
        if(sensors[0].car!= null && sensors[1].car!= null && sensors[2].car!= null && sensors[3].car!= null )
        {
            if(!sensors[1].car.isOvertaking && !sensors[2].car.isOvertaking)
            {
                sensors[1].car.Overtake();
                sensors[1].car.isOvertaking = true;
                sensors[2].car.Overtake();
                sensors[2].car.isOvertaking = true; 
            }
        }
    }
}
