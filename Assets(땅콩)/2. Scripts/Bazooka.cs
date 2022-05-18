using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    private Animator anim;                    // Animator component를 위한 Reference


    public PlayerCtrl playerCtrl;            // PlayerCtrl script를 위한 Reference


    public Rigidbody2D rocket;                // rocket의 Prefab 연결 레퍼런스
    public float rocketSpeed = 20f;            // 로켓은 이 스피드로 저격 할 것이다

    public bool shootting;
    
    
    void Awake()
    {
        // Reference들의 셋팅
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.root.GetComponent<PlayerCtrl>();
    }

    
    void Update ()
    {
        // 만약 fire 버튼이 눌렸다면
        if( Input.GetButtonDown("Fire1") )
        {
            shootting = false;
            // animator의 trigger(전환) parameter에 Shoot를 셋팅하고 오디오클립을 플레이
            anim.SetTrigger("Shoot");
            GetComponent<AudioSource>().Play();
            
            // 만약 플레이어가 오른쪽 방향이라면 
            if(playerCtrl.dirRight)
            {
                // 오른쪽 방향으로 로켓을 생성하고 오른쪽으로 로켓의 속도를 셋팅
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(rocketSpeed, 0);
            }
            else
            {
                // 그렇지 않으면 왼쪽 방향으로 로켓을 생성하고 왼쪽으로 로켓의 속도를 셋팅
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-rocketSpeed, 0);
            }
        }
    }
}
