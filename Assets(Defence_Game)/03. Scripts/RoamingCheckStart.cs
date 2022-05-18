using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingCheckStart : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //coll.gameObject.GetComponent<EnemyCtrl>().RoamingCheckStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
