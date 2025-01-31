using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnenmy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float minSpawnTime;

    [SerializeField]
    private float maxSpawnTime;

    private float timeTillSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeTillSpawn -= Time.deltaTime;

        if(timeTillSpawn <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.Euler(0, 180, 0));
            SetTimeUntilSpawn();
        }
 
    }

    private void SetTimeUntilSpawn()
    {
        timeTillSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
