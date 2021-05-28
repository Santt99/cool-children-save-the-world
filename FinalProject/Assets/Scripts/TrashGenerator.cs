using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 spawnRange;

    public Vector2 spawnRangePositionY;

    public Vector2 spawnRangePositionX;

    public Vector2 spawnRangePositionYMan;

    public Vector2 spawnRangePositionXMan;

    public Vector2 spawnRangeTime;
    public Vector2 spawnRangeTimeMan;

    public GameObject trash;
    public GameObject man;

    private float timeT;
    private float timeM;

    private float timeToSpawn;
    private float timeToSpawnMan;
    void Start()
    {
        timeToSpawn = Random.Range(spawnRangeTime.x, spawnRangeTime.y);
        timeToSpawnMan = Random.Range(spawnRangeTimeMan.x, spawnRangeTimeMan.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeT >= timeToSpawn)
        {
            SpawnTrash();
            timeToSpawn = Random.Range(spawnRangeTime.x, spawnRangeTime.y);
            timeT = 0;
        }
        if (timeM >= timeToSpawnMan)
        {
            SpawnMan();
            timeToSpawnMan = Random.Range(spawnRangeTimeMan.x, spawnRangeTimeMan.y);
            timeM = 0;
        }
        timeT += Time.deltaTime;
        timeM += Time.deltaTime;
    }

    private void SpawnTrash()
    {
        float maxInstances = Random.Range(spawnRange.x, spawnRange.y);
        for (var i = 0; i < maxInstances; i++)
        {
            float positionX = Random.Range(spawnRangePositionX.x, spawnRangePositionX.y);
            float positionY = Random.Range(spawnRangePositionY.x, spawnRangePositionY.y);
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
            Vector3 randomPosition = new Vector3(positionX, positionY, 0);
            Instantiate(trash, randomPosition, randomRotation);
        }
    }

    private void SpawnMan()
    {
        float maxInstances = 1;
        for (var i = 0; i < maxInstances; i++)
        {
            float positionX = Random.Range(spawnRangePositionXMan.x, spawnRangePositionXMan.y);
            float positionY = Random.Range(spawnRangePositionYMan.x, spawnRangePositionYMan.y);
            Vector3 randomPosition = new Vector3(positionX, positionY, 0);
            Instantiate(man, randomPosition, Quaternion.identity);
        }
    }
}
