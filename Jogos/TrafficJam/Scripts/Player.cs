using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Variáveis do Carro")]
    public GameObject mesh;
    public float speed;
    public float maxRotationCar;

    [Header("Variáveis do Pneu")]
    public float rotation;
    public float rotationSpeed;

    [Header("Variáveis do Limite")]
    public float horizontalLimit; 

    GameObject FL; 
    GameObject FR;
    float rotationY;
    float carRotation; 

    public static Player instance; 

    void Start()
    {
        instance = this; 

        GameObject carInstance = Instantiate(mesh, transform);
        carInstance.transform.position = transform.position;

        //procurando rodas        
        for(int i=0;i<transform.GetChild(0).transform.childCount;i++)
        {
            if(transform.GetChild(0).transform.GetChild(i).gameObject.name == "FL")
                FL = transform.GetChild(0).transform.GetChild(i).gameObject;
            if(transform.GetChild(0).transform.GetChild(i).gameObject.name == "FR")
                FR = transform.GetChild(0).transform.GetChild(i).gameObject;
        }
        if(FL == null || FR == null) Debug.Log("ERRO! Pneus não encontrados"); //depuração para diferentes tipos de veiculos
    }

    void Update()
    {
        int x = 0; 
        if(Input.GetAxis("Horizontal")>0) x=1;
        if(Input.GetAxis("Horizontal")<0) x=-1; 

        if(transform.position.x>horizontalLimit && x>0) x=0; 
        else if(transform.position.x<-horizontalLimit && x<0) x=0;
        
        if(x!=0)
        {   
            rotationY = Mathf.Lerp(rotationY, x > 0 ? rotation : -rotation, Time.deltaTime*rotationSpeed);
            carRotation = Mathf.Lerp(carRotation, x>0 ? maxRotationCar : - maxRotationCar, Time.deltaTime*rotationSpeed);
            GetComponent<Rigidbody>().velocity = new Vector3(speed*x, -1f, 0);
        }
        else
        {
            rotationY = Mathf.Lerp(rotationY, 0, Time.deltaTime*rotationSpeed*2f);
            carRotation = Mathf.Lerp(carRotation, 0, Time.deltaTime*rotationSpeed*2f);
            if(carRotation!=0)
                GetComponent<Rigidbody>().velocity = new Vector3(speed*carRotation/maxRotationCar, -1f, 0);
            else
                GetComponent<Rigidbody>().velocity = Vector3.zero; 
        }
        FL.transform.eulerAngles = new Vector3(0,rotationY+90f,0);
        FR.transform.eulerAngles = new Vector3(0,rotationY+90f,0);
        transform.eulerAngles = new Vector3(0, carRotation, 0);
    }
}
