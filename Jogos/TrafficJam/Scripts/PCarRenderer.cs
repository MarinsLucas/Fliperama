using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCarRenderer : MonoBehaviour
{
    public Gradient grad; 
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = grad.Evaluate(Random.Range(0f,100f)/100f);
    }
}
