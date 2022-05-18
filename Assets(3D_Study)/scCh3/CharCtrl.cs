using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCtrl : MonoBehaviour
{
    public GameObject bloodEffect;
    public Weapon weapon;
    public int Hp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon"
            && !collision.gameObject.GetComponent<Weapon>().isMine)
        {
            Damage(collision.contacts[0].point, weapon.power);    
        }
    }

    public void Damage(Vector3 pos, int damage)
    {
        StartCoroutine(this.CreateBloodEffect(pos, damage));
    }

    IEnumerator CreateBloodEffect(Vector3 pos, int damage)
    {
        Instantiate(bloodEffect, pos, Quaternion.identity);

        Hp -= damage;
        yield return null;
    }
}
