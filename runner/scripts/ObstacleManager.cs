using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject[] obstaclePrefabs;
    // private Transform playerTransform;
    private float spawnZ = 20.0f;
     private float spawnGap = 6.0f;
    //private float safeZone = 32.0f;
    // private int amnTilesOnScreen = 7;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeObstacles;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle2();
        //activeObstacles = new List<GameObject>();
    }
		// Update is called once per frame
		void Update()
		{

		}


		public void SpawnObstacle()
		{
			// Choose a random point to spawn the obstacle
			int obstacleSpawnIndex = Random.Range(1, 4);
			Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

			// Spawn the obstace at the position
			Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
		}

    public void SpawnObstacle2(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(obstaclePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(obstaclePrefabs[prefabIndex]) as GameObject;
        }

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += spawnGap;
        activeObstacles.Add(go);

    }

    private int RandomPrefabIndex()
    {
        if (obstaclePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, obstaclePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}