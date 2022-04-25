 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public CarSpawnerPosition[] pos;
    public Car[] prefab;
    public float spawnInterval;  
    float spawnTimer; 

    void Start()
    {
        spawnTimer = spawnInterval;
    }
    
    //função que spawna o carro
    void SpawnCar(Car car, CarSpawnerPosition p, int index)
    {
        GameObject carInstance = Instantiate(car.gameObject, this.gameObject.transform.parent);
        carInstance.transform.position = p.gameObject.transform.position; 
        p.car = carInstance.GetComponent<Car>(); 

        if(!p.inFlow)
        {
            p.car.speed = 4f;
            p.car.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            p.car.speed = 2.5f; 
        }
        p.car.index = (short)index; 
    }

    void Update()
    {
        if(spawnTimer <= 0)
        {
            short quant = (short)Random.Range(1 ,3);
            for(int i=0; i<quant;i++)
            {
                int x = Random.Range(0, 4);
                while(pos[x].car != null) x = Random.Range(0, 4);
                SpawnCar(prefab[Random.Range(0, prefab.Length)], pos[x], x);
            }

            spawnTimer = spawnInterval; 
        }
        spawnTimer -= Time.deltaTime;
        //voltando todas as posições para o valor nulo
        pos[0].car = null;
        pos[1].car = null; 
        pos[2].car = null; 
        pos[3].car = null; 
    }
}
