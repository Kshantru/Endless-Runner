using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    // private Transform playerTransform;
    // private float spawnZ = 20.0f;
    // private float tileLength = 20.0f;
    //private float safeZone = 32.0f;
    // private int amnTilesOnScreen = 7;
    //private int lastPrefabIndex = 0;

    //private List<GameObject> activeObstacles;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
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
	}