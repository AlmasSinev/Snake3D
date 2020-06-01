using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public Transform spawnZone;
    public GameObject objToSpawn;

    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;


    // Start is called before the first frame update
    void Start()
    {
        maxX = spawnZone.position.x + spawnZone.localScale.x / 2;
        maxX = spawnZone.position.x - spawnZone.localScale.x / 2;

        maxX = spawnZone.position.z + spawnZone.localScale.z / 2;
        maxX = spawnZone.position.z - spawnZone.localScale.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
