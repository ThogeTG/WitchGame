using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public bool spawnDirectionRight;
    public int enemySpawns;
    public float spawnTime;
    public Transform spawnLocation;

	// Use this for initialization
	void Start ()
    {
        

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0 && enemySpawns >= 0)
        {
            Spawn();
        }
    }

    void Spawn ()
    {
        Instantiate(enemy, spawnLocation);

        spawnTime = 3;

        enemySpawns--;
    }
}
