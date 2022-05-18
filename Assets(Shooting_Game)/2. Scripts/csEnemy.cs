using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemy : MonoBehaviour
{

    /////////////// 수정 //////////////////
    public static csEnemy instance;
    void Awake()
    {
        if(csEnemy.instance == null)
        {
            csEnemy.instance = this;
        }
    }
    //////////////////////////////////////////


    public float moveSpeed = 1.0f;
    public GameObject explosionPrefab;
    int killScore = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        if(Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 0.1f;
            float yMove = moveSpeed * Time.deltaTime;
            transform.Translate(0, -yMove,0);
        }
        else
        {
            moveSpeed = 0.6f;
            float yMove = moveSpeed * Time.deltaTime;
            transform.Translate(0, -yMove,0);
        }
    }

    void MoveEnemy()
    {
        float yMove = moveSpeed * Time.deltaTime;
        transform.Translate(0, -yMove,0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.instance.PlaySound();
            GameManager.instance.KillPlayer();
            // Destroy(col.gameObject);

            col.gameObject.SetActive(false);
            csPlayer.canShoot = false;
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "Laser")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.instance.PlaySound();
            GameManager.instance.AddScore(killScore);

            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
            // 총알 메모리폼

            //Destroy(gameObject);
            gameObject.SetActive(false);
            // 적기 메모리폼
        }
    }
}
