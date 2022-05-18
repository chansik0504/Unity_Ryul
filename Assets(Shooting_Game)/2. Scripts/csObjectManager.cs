using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csObjectManager : MonoBehaviour
{
    public static csObjectManager instance;
    public GameObject laserPrefab;
    List<GameObject> bullets = new List<GameObject>();

    public GameObject GetBullet(Vector3 pos)
    {
        GameObject reqBullet = null;
        for(int i = 0 ; i < bullets.Count; i++)
        {
            if(bullets[i].activeSelf == false)
            {
                reqBullet = bullets[i];
                break;
            }
        }


        if (reqBullet == null)
        {
            GameObject newBullet = Instantiate(laserPrefab) as GameObject;
            newBullet.transform.parent = transform;
            bullets.Add(newBullet);
            reqBullet = newBullet;
        }

        reqBullet.SetActive(true);
        reqBullet.transform.position = pos;

        return reqBullet;
    }

    void Awake()
    {
        if(csObjectManager.instance == null)
        {
            csObjectManager.instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateBullets(5);
        CreateEnemies(3);
    }

    void CreateBullets(int bulletCount)
    {
        for(int i = 0 ; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(laserPrefab) as GameObject;
            bullet.transform.parent = transform;
            bullet.SetActive(false);

            bullets.Add(bullet);
        }
    }

    public void Clearbullets()
    {
        for(int i = 0 ; i < bullets.Count; i++)
        {
            bullets[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     // 원래 속도
        //     // player == 1.5f
        //     // laser == 1.0f
        //     // Enemy == 1.0f;
        //     csEnemy.instance.moveSpeed = 0.2f;
        //     csPlayer.instance.moveSpeed = 0.5f;
        //     csLaser.instance.moveSpeed = 0.2f;

        //     // for(int i = 0 ; i < csObjectManager.instance.bullets.Count; i++)
        //     // {
        //     //     csObjectManager.instance.bullets[i].
        //     // }
        // }
    }


    ////////// 적 메모리풀 ///////////////

    public GameObject enemyPrefab;
    List<GameObject> Enemies = new List<GameObject>();

    void CreateEnemies(int EnemyCount)
    {
        for(int i = 0 ; i < EnemyCount; i++)
        {
            GameObject Enemy = Instantiate(enemyPrefab) as GameObject;
            Enemy.transform.parent = transform;
            Enemy.SetActive(false);

            Enemies.Add(Enemy);
        }
    }

    public GameObject GetEnemy(Vector3 pos)
    {
        GameObject reqEnemy = null;
        for(int i = 0 ; i < Enemies.Count; i++)
        {
            if(Enemies[i].activeSelf == false)
            {
                reqEnemy = Enemies[i];
                break;
            }
        }

        if (reqEnemy == null) 
        {
            GameObject newEnemy = Instantiate(enemyPrefab) as GameObject;
            newEnemy.transform.parent = transform;
            Enemies.Add(newEnemy);
            reqEnemy = newEnemy;
        }

        reqEnemy.SetActive(true);
        reqEnemy.transform.position = pos;

        return reqEnemy;
    }

    public void ClearEnemies()
    {
        for(int i = 0 ; i < Enemies.Count; i++)
        {
            Enemies[i].SetActive(false);
        }
    }
}
