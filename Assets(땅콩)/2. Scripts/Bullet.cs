using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void OnExplode()
    {
		// 회전값 저장을 위한 Quaternion 변수를 Z축방향으로 렌덤한 rotation 값으로  생성 및 초기화
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		
		// 충돌한 로켓의 위치에 randomRotation 각도로 explosion 객체(인스턴스)가 생성된다
		Instantiate(explosion, transform.position, randomRotation);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Hurt();
            OnExplode();
            Destroy(gameObject);
        }
        else if (col.tag == "BombPickup")
        {
			// 충돌된 폭탄상자의 Bomb script를 찾고 Explode()함수를 호출 
			col.gameObject.GetComponent<Bomb>().Explode();
			
			// 폭탄 상자 destroy
			Destroy (col.transform.root.gameObject);
			
			// 로켓 삭제
			Destroy (gameObject);
        }
        else if (col.gameObject.tag != "Player")
        {
            OnExplode();
            Destroy(gameObject);
        }
    }
}
