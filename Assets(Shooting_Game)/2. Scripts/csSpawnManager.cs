using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSpawnManager : MonoBehaviour
{
    Vector3[] positions = new Vector3[99];

    public GameObject enemyPrefab;
    public static bool isSpawn = false;

    float spawnDelay = 1.5f;
    float spawnTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreatePositions();
    }

    void CreatePositions()
    {
        float viewPosY = 1.2f;
        
        float gapX = 1 / 100.0f;
        float viewPosX = 0.0f;

        for (int i = 0 ; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);

            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.z = 0.0f;

            positions[i] = worldPos;

            Debug.Log(positions[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if(isSpawn == true)
        {
            if(spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);
                //Instantiate(enemyPrefab, positions[rand], Quaternion.identity);
                csObjectManager.instance.GetEnemy(positions[rand]);
                spawnTimer = 0.0f;
            }

            if(Input.GetKey(KeyCode.Space))
            {
                spawnTimer += Time.deltaTime * 4;
            }
            else
            {
                spawnTimer += Time.deltaTime * 20;
            }
        }
    }
}
