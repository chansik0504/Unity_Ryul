using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Vector3 offset;            // 플레이어를 따라다니는 라이프 바의 offset
    private Transform player;        // player을 위한 레퍼런스
    
    
    void Awake ()
    {
        // 레퍼런스(참조)을 셋팅.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update ()
    {
        // offset셋과 함께 player의 position으로 현재 게임오브젝트의 position을 셋팅 
        transform.position = player.position + offset;
    }
}
