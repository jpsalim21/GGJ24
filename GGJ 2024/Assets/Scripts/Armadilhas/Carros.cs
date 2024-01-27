using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carros : MonoBehaviour
{
    [SerializeField] GameObject carro;
    [SerializeField] int tamanho;
    Queue<GameObject> pool;

    [SerializeField] float timeToSpawn;
    float timePassed;

    void Start()
    {
        pool = new Queue<GameObject>();
        for(int i = 0; i < tamanho; i++)
        {
            GameObject a = Instantiate(carro, transform);
            pool.Enqueue(a);
            a.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(timePassed <= 0)
        {
            timePassed = timeToSpawn;
            SpawnCarro();
        } else
        {
            timePassed -= Time.deltaTime;
        }
    }
    void SpawnCarro()
    {
        GameObject a = pool.Dequeue();

        a.SetActive(true);
        a.transform.position = transform.position;

        pool.Enqueue(a);
    }
}
