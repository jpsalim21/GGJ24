using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carros : MonoBehaviour
{
    [SerializeField] GameObject[] carro;
    [SerializeField] int tamanho;
    [SerializeField] Transform destino;
    Queue<GameObject> pool;

    [SerializeField] float timeToSpawn, timeMaxSpawn;
    float timePassed;

    void Start()
    {
        pool = new Queue<GameObject>();
        for(int i = 0; i < tamanho; i++)
        {
            int index = Random.Range(0, carro.Length);
            GameObject a = Instantiate(carro[index], transform);
            a.GetComponent<MoveCarro>().destino = this.destino.position;
            pool.Enqueue(a);
            a.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(timePassed <= 0)
        {
            timePassed = Random.Range(timeToSpawn, timeMaxSpawn);
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
