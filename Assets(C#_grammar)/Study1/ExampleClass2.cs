using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ApplyDamage()
    {
        Debug.Log("Damage : Ignored");
    }
    void ApplyDamage(float damage)
    {
        Debug.Log("ExampleClass2 Damage : " + damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
