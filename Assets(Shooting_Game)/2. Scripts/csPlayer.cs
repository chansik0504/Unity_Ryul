using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayer : MonoBehaviour
{
    /////////////// 수정 //////////////////
    public static csPlayer instance;
    void Awake()
    {
        if(csPlayer.instance == null)
        {
            csPlayer.instance = this;
        }
    }
    //////////////////////////////////////////
    public float moveSpeed = 0.5f;

    //public GameObject laserPrefab;
    public static bool canShoot = false;

    float shootDelay = 0.5f;
    float shootTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ShootLaser();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 0.5f;
            float moveX = moveSpeed * Time.deltaTime *
                Input.GetAxis("Horizontal");
            transform.Translate(moveX,0,0);

            float moveY = moveSpeed * Time.deltaTime *
                Input.GetAxis("Vertical");
            transform.Translate(0,moveY,0);

            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            viewPos.x = Mathf.Clamp01(viewPos.x);
            viewPos.y = Mathf.Clamp01(viewPos.y);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);

            transform.position = worldPos;
        }

        else
        {
            moveSpeed = 1.0f;
            float moveX = moveSpeed * Time.deltaTime *
                Input.GetAxis("Horizontal");
            transform.Translate(moveX,0,0);

            float moveY = moveSpeed * Time.deltaTime *
                Input.GetAxis("Vertical");
            transform.Translate(0,moveY,0);

            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            viewPos.x = Mathf.Clamp01(viewPos.x);
            viewPos.y = Mathf.Clamp01(viewPos.y);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);

            transform.position = worldPos;
        }
    }

    void ShootLaser()
    {
        if(canShoot == true)
        {
            if(shootTimer > shootDelay)
            {
                //Instantiate(laserPrefab, transform.position, Quaternion.identity);
                csObjectManager.instance.GetBullet(transform.position);
                shootTimer = 0.0f;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                shootTimer += Time.deltaTime / 4.0f;
            }
            else
            {
                shootTimer += Time.deltaTime / 2.0f;
            }
        }
    }
}