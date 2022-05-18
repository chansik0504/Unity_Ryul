using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_SendMessage : MonoBehaviour
{

    void Start()
    {
        // 반대로 하는법 ( 부모 -> 자식 메시지 전달 )
        // gameObject.BroadcastMessage("ApplyDamage", 5.0f);
    }

    void ApplyDamage(float damage)
    {
        Debug.Log("Parent Damage : " + damage);
    }
}
