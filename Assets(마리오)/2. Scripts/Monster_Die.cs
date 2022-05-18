using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Die : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Sprite Dead_With_Foot;
    public Sprite Dead_With_Bullet;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D Who)
    {
        if(Who.tag == "Foot")
        {
            Who.transform.root.GetComponent<Mario_Control>().jumpForce = 10;
            Who.transform.root.GetComponent<Mario_Control>().jump = true;
            Who.transform.root.GetComponent<Mario_Control>().jumpForce = 250;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = Dead_With_Foot;
            Vector3 TempScale = transform.localScale;
            TempScale.x = 1;
            TempScale.y = 1;
            transform.localScale = TempScale;
            
            this.GetComponent<BoxCollider2D>().enabled = false;
            // Vector2 A = new Vector2(0,0);
            // this.GetComponent<BoxCollider2D>().size = A;
            this.GetComponentInChildren<BoxCollider2D>().enabled = false;
            this.GetComponentInChildren<CircleCollider2D>().enabled = false;
            transform.Find("Turn").gameObject.SetActive(false);
            transform.Find("Body").gameObject.SetActive(false);
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Destroy(this.gameObject, 1);
        }
        else if (Who.tag == "Bullet")
        {
            // 미사일 사망 애니 실행
        }
        else if (Who.tag == "Mario")
        {
            // 마리오가 죽는 애니 실행 // ?? 이건 마리오에 넣어줘아햐나?
        }
    }
}
