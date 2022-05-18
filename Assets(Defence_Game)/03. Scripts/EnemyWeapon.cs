using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int power;
    public Collider co;

    void OnCollistionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StartCoroutine(this.ResetColl());
        }
    }

    IEnumerator ResetColl()
    {
        co.enabled = false;
        yield return new WaitForSeconds(1.5f);
        co.enabled = true;
    }
}
