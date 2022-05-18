using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float moveSpeed = 2f;		// 몬스터의 이동 속도 
	public int HP = 2;					// 몬스터의 생명력  
	public Sprite deadEnemy;			// 몬스터가 죽었을때 교체할 몬스터의 스프라이트 
	public Sprite damagedEnemy;			// 몬스터가 데미지를 입었을때 교체할 몬스터의 스프라이트 (선택적이다)
	public AudioClip[] deathClips;		// 몬스터가 죽었을때 플레이할 수 있는 오디오 클립 배열 
	public GameObject hundredPointsUI;	// 몬스터가 죽었을때 발생하는 100의 프리팹 
	public float deathSpinMin = -100f;	// 몬스터가 죽었을때 회전력의 최소량을 주기 위한 값
	public float deathSpinMax = 100f;	// 몬스터가 죽었을때 회전력의 최대량을 주기 위한 값
	
	
	private SpriteRenderer ren;			// SpriteRenderer 컴포넌트를 위한 레퍼런스 
	private Transform frontCheck;		// 만약 무엇이든 몬스터 앞에 있다면 체크를 위헤 사용되는 gameobject의 position을 위한 Reference 
	private bool dead = false;			// 몬스터가 죽었는지 아닌지를 위한 변수 
	private Score score;				// Score 스크립트를 위한 레퍼런스 
	
	
	void Awake()
	{
		// 레퍼런스들의 셋팅 
		ren = transform.Find("body").GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("frontCheck").transform;
		score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	void FixedUpdate ()
	{
		// enemy 앞에 모든 콜라이더들의 배열을 생성 (PlayerCtrl 스크립트의 Physics2D.Linecast()함수 참고 )
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);
		// Collider[] frontHits = Physics.OverlapSphere (Vector3 position, float radius); 3D 일때

		// 콜라이더들 각각을 체크 
		foreach(Collider2D c in frontHits)
		{
			// 만약 어떤 콜라이더의 테그가 Obstacle 이라면 ...
			if(c.tag == "Obstacle")
			{
				// 다른 콜라이더들을 체크하는것을 멈추고 몬스터를 뒤집어라 
				Flip();
				break;
			}
		}
		
		// 몬스터의 속도를 x축방향 moveSpeed 으로 셋팅 
		// localScale을 이용하여 스케일의 크기 만큼 속도가 증가하며, 방향 전환(Flip())시 localScale 은 x축에 (-1)이 곱해져서 반대 방향으로 이동 
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);	
		
		// 만약 몬스터의 HP가 1이고 damagedEnemy 스프라이트가 연결되어 있을때 
		if(HP == 1 && damagedEnemy != null)
			// SpriteRenderer 컴포넌트에 멤버 sprite에 damagedEnemy 스프라이트 연결 
			ren.sprite = damagedEnemy;
		
		// 만약 몬스터의 HP가 0 또는 0 미만 이고 아직 살아잇다면 죽이자 ...
		if(HP <= 0 && !dead)
			// Death ()함수 호출 
			Death ();
	}
	
	public void Hurt()
	{
		// 몬스터의 생명력을 1 만큼 줄인다.
		HP--;
	}
	
	void Death()
	{
		// 이 게임오브젝트를 포함하여 하위로 있는 자식 게임오브젝트에서 SpriteRenderer 컴포넌트들을 모두 찾는다.
		SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();
		
		// 모든 SpriteRenderer 컴포넌트를 Disable 한다.
		foreach(SpriteRenderer s in otherRenderers)
		{
			s.enabled = false;
		}
		
		// 메인(body)인 ren이 가리키는 SpriteRenderer를 다시 활성화 하고, SpriteRenderer 컴포넌트에 멤버 sprite에 deadEnemy 스프라이트로 셋팅    
		ren.enabled = true;
		ren.sprite = deadEnemy;
		
		// 100 포인트의 스코어 증가 
		score.score += 100;
		
		// dead를 true로 셋팅 
		dead = true;           
		
		// 몬스터의 회전을 위해 fixedAngle을 false로 하고 회전력의 추가에의해서 몬스터를 회전시키자.
		GetComponent<Rigidbody2D>().fixedAngle = false;
		//z 축으로 회전 
		GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin,deathSpinMax));
		
		// 게임오브젝트에 Collider2D 컴포넌트들을 모두 찾은 다음  Collider2D 컴포넌트가 모두 trigger가 되게 셋팅 하자.
		Collider2D[] cols = GetComponents<Collider2D>();
		foreach(Collider2D c in cols)
		{
			c.isTrigger = true;
		}
		
		// deathClips 배열로부터 랜덤하게 audioclip을 플레이 하자
		int i = Random.Range(0, deathClips.Length);
		AudioSource.PlayClipAtPoint(deathClips[i], transform.position);
		
		// 몬스터 바로 위에 벡터를 생성 
		Vector3 scorePos;
		scorePos = transform.position;
		scorePos.y += 1.5f;
		
		// 이 벡터지점에서 100 포인트 프리팹을 인스턴스로 만들자.
		Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
	}
	
	
	public void Flip()
	{
		// -1을 Transform 컴포넌트에 요소 localScale(벡터)의 x축에 곱하자.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
