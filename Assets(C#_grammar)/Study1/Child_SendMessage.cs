using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_SendMessage : MonoBehaviour
{
    void Start()
    {
        gameObject.SendMessageUpwards("ApplyDamage", 5.0f);
    }

    void ApplyDamage(float damage)
    {
        Debug.Log("Child Damage : " + damage);
    }
}
