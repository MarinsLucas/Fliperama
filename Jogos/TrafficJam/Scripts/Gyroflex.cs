using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroflex : MonoBehaviour
{
    public GameObject red; 
    public GameObject blue; 
    float time = 0.3f;
    bool p = true; 

    void Update()
    {
        if(time <= 0f)
        {
            red.SetActive(p);
            blue.SetActive(!p);
            time = 0.3f;
            p = !p;
        }
        time -= Time.deltaTime/Time.timeScale; 
    }
}
