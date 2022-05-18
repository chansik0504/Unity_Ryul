using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
	private Animator anim;						// Player객체의 포함된 Animator 컴포넌트를 위한 Reference


	private PlayerCtrl playerCtrl;				// PlayerCtrl 컴포넌트를 위한 Reference

	private SpriteRenderer lifeBar;				// life Bar의 SpriteRenderer 컴포넌트를 위한 Reference

	public AudioClip[] ouchClips;				// 플레이어가 데미지를 받을때 플레이되는 클립 배열 


	public float life = 100f;					// 플레이어의 생명 변수 
	public float damageAmount = 10f;			// 적들이 플레이어를 타격할때 플레이어가 입는 데미지는의 양 
	public float hurtForce = 10f;				// 플레이어가 몬스터에게 타격당할때 설정 힘으로 밀려난다.
	public float repeatDamagePeriod = 2f;		// 얼마나 자주 플레이어가 데미지를 받을수 있는지를 설정

	private Vector3 lifeScale;					// 최초(life 게이지가 꽉 찬 상태) life bar의 local scale를 저장하기 위한 변수  
	private float lastHitTime;					// 플레이어가 마지막으로 타격 당했을때의 시간 
	
	
	void Awake ()
	{
		// 레퍼런스들의 셋팅 
		anim = GetComponent<Animator>();
		playerCtrl = GetComponent<PlayerCtrl>();
		lifeBar = GameObject.Find("Life").GetComponent<SpriteRenderer>();

		// lifeBar의 초기 scale값을 얻는다.(플레이어가 가득찬 라이프 상태일때 )
		lifeScale = lifeBar.transform.localScale;
	}
	

	// 충돌 CallBack 함수
	void OnCollisionEnter2D (Collision2D col)
	{
		// 만약 충돌한 gameobject가 Enemy라면 
		if(col.gameObject.tag == "Enemy")
		{
			// 그리고 만약 시간이 (마지막 충돌된 시간 + 재 충돌의 시간) 를 초과 한다면 
			if (Time.time > lastHitTime + repeatDamagePeriod) 
			{
				// 그리고 만약 플레이어가 아직까지 생명력이 0 이상이면 
				if(life > 0f)
				{
					// 데미지를 줘라 그리고 lastHitTime을 리셋하자
					TakeDamage(col.transform); 
					lastHitTime = Time.time; 
				}
				//그렇지 않고 만약 플레이어가 생명력이 0 이하이면 스테이지 리셋을 위해 플레이어를 강으로 떨어뜨리자
				else
				{
					// 플레이어의 모든 sprite들을 맨 앞으로 이동 시키자.
					SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
					foreach(SpriteRenderer s in spr)
					{
						s.sortingLayerName = "UI";
					}

					// gameobject에 포함된 collider들을 모두 찾은다음 그 컴포넌트들을 모두 trigger(충돌시 통과됨) 가 되도록 설정 
					Collider2D[] cols = GetComponents<Collider2D>();
					foreach(Collider2D c in cols)
					{
						c.isTrigger = true;
					}

					// 사용자 PlayerCtrl script를 비 활성화 하자 
					GetComponent<PlayerCtrl>().enabled = false;

					// 죽은 플레이어가 존재하지 않는 바주카를 발사하는것을 막기위해 사용자 Bazooka script를 비 활성화 하자
					GetComponentInChildren<Bazooka>().enabled = false;

					// Animator의 'Die' animation state(상태) 로 전환된다.
					anim.SetTrigger("Die");
				}
			}
		}
	}


	// 적에게 데미지를 받는 함수
	void TakeDamage (Transform enemy)
	{
		//반드시 플레이어가 점프를 할수없게 하자 
		playerCtrl.jump = false;

		// 위쪽 힘과 함께 적에서 부터 플레이어까지를 담을 수 있는 vector의 생성 
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;

		// hurtVector 와 hurtForce에 의해서 곱해진 Vector의 방향으로 플레이어에게 힘을 가하자 
		GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

		//플레이어의 life를 10 줄이자
		life -= damageAmount;

		// life bar와 관련된 것을 Update 하자.
		UpdateLifeBar();

		//플레이어가 상처입었을때의 오디오 클립을 랜덤하게 플레이하자
		int i = Random.Range (0, ouchClips.Length);
		AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
	}
	

	// 피격시 life bar의 Update 함수
	public void UpdateLifeBar ()
	{
		// life bar의 전체적인 색상을 green에서 -> red로 (0.01f만큼) 서서히 넘어 가는 방법으로 플레이어의 생명력을 설정하자.
		lifeBar.material.color = Color.Lerp(Color.green, Color.red, 1 - life * 0.01f);

		// 플레이어의 생명력과 비례되게 life bar의 scale을 설정하자.
		lifeBar.transform.localScale = new Vector3(lifeScale.x * life * 0.01f, 1, 1);
	}
}