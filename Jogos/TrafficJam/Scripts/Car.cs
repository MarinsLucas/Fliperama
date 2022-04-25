using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //TODO: Fazer o carro ser destruído quando for para frente também
    
    public Gradient grad; //gradiente de cores possíveis
    public float speed; //velocidade vertical do carro
    Renderer rend;
    public float bottomLimit; //final da estrada (onde o carro é destruído)
    public short index; 

    public float timeToOvertake; //Tempo em que a velocidade se altera durante a ultrapassagem
    
    //variáveis para a ultrapassagem
    public bool isOvertaking;
    float signing = 0.3f; 
    bool movingHorizontal; 

    //setas de direção
    public GameObject signs;
    bool p; 
    
    void Start()
    {
        //colore o carro aleatóriamente de acordo com o gradiente
        rend = gameObject.GetComponentInChildren<Renderer>();
        rend.material.color = grad.Evaluate(Random.Range(0f, 100f)/100f);

        //movimento inicial do carro
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed); 

        isOvertaking = false; 
        p = false; 
    }

    void Update()
    {
        //limite vertical
        if(transform.position.z < 0f)
            Destroy(gameObject);
        
        //Secção da ultrapassagem
        if(isOvertaking)
        {
            //sistema de setas
            if(signing >= 0.3f)
            {
                p = !p;
                signs.SetActive(p);
                signing = 0f; 
            }
            signing += Time.deltaTime/Time.timeScale; 
            
            //finalizando a ultrapassagem
            if(movingHorizontal)
            {
                if(index==1)
                {
                    float y = transform.position.x;
                    y = Mathf.Lerp(y, -2.4f, 1.5f*Time.deltaTime);
                    transform.position = new Vector3(y, transform.position.y, transform.position.z);
                }
                else
                {
                    float y = transform.position.x; 
                    y = Mathf.Lerp(y, 2.4f, 1.5f*Time.deltaTime);
                    transform.position = new Vector3(y, transform.position.y, transform.position.z);
                }
            }
        }
        //inverte a direção do movimento dos carros das faixas da direita
        if(!GameManager.instance.isRunning)
        {
            if(index>=2) GetComponent<Rigidbody>().velocity = new Vector3(0,0,speed*2);
            else GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed/2);
        }
        
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
            Destroy(other.gameObject.GetComponent<Player>());
            Destroy(GetComponent<Car>());
        }    
        if(other.gameObject.tag == "car")
        {
            if(!isOvertaking)
            {
                Destroy(other.gameObject.GetComponent<Player>());
                Destroy(GetComponent<Car>());
            }
        }
    }
    
    //observação do sensor do controle de tráfico para as ultrapassagens
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TrafficControl")
        {
            other.gameObject.GetComponent<TrafficSensor>().car = this;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "TrafficControl")
        {
            other.gameObject.GetComponent<TrafficSensor>().car = null; 
        }
    }
    
    
    IEnumerator StopOvertaking()
    {
        //avança em linha reta
        movingHorizontal = false; 
        yield return new WaitForSeconds(timeToOvertake*0.75f);
        movingHorizontal = true; 
        yield return new WaitForSeconds(timeToOvertake*0.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0, -speed);
       
        isOvertaking = false; 
        signs.SetActive(false);
        p = false; 
    }
    
    //altera temporariamente a velocidade durante a ultrapassagem
    public void Overtake()
    {
        if(index==1)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed*1.5f);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed*0.5f);
        }
        StartCoroutine(StopOvertaking());
    }
}
