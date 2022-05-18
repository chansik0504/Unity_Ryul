using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float bombRadius = 10f;			// 반지름 범위 이내에 몬스터들은 죽임을 당함 
	public float bombForce = 100f;			// 폭발로 몬스터들에게 가지는 힘
	public AudioClip boom;					// 폭발 오디오 클립 
	public AudioClip fuse;					// 퓨즈의 오디오 클립 
	public float fuseTime = 1.5f;
	public GameObject explosion;			// 폭발 이팩트 프리팹 
	
	
	private LayBombs layBombs;				// Player게임 오브젝트의 LayBombs script를 위한 참조
	private PickupSpawner pickupSpawner;	// PickupSpawner script를 위한 레퍼런스
	private ParticleSystem explosionFX;		// 폭발 이팩트의 particle system을 위한 레퍼런스(참조)
	
	
	void Awake ()
	{
		// 레퍼런스(참조)들을 셋팅.
		explosionFX = GameObject.FindGameObjectWithTag("ExplosionFX").GetComponent<ParticleSystem>();
		pickupSpawner = GameObject.Find("PickupSpawner").GetComponent<PickupSpawner>();
		if(GameObject.FindGameObjectWithTag("Player"))
			layBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<LayBombs>();
	}
	
	void Start ()
	{
		
		// 만약 bomb 오브젝트의 부모객체가 없다면 이것은 플레이어에 의해서 놓여진 것이다 따라서 폭발 시켜야한다.
		if(transform.root == transform)
			StartCoroutine(BombDetonation());
	}
	
	
	IEnumerator BombDetonation()
	{
		// fuse 오디오 클립을 플레이
		AudioSource.PlayClipAtPoint(fuse, transform.position);
		
		// 2초 기달리고
		yield return new WaitForSeconds(fuseTime);
		
		// bomb 폭발 
		Explode();
	}
	
	
	public void Explode()
	{
		
		// 플이어가 폭탄을 다시 얻을때 폭탄을 다시 던질수있다  
		layBombs.bombLaid = false;
		
		// PickupSpawner가 새로운 아이탬을 배달을 시작하도록 만들자 
		pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());
		
		// 폭발반경 안에 Enemies 레이어로 모든 몬스터 콜라이더를 찾는다.
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Enemies"));
		
		// 각 콜라이더를 셋팅
		foreach(Collider2D en in enemies)
		{
			// 만약 이 콜라이더의 객체가 rigidbody를 가지고있으면 체크 (parent에 각 몬스터당 오직 하나의 rigidbody가 있음)
			Rigidbody2D rb = en.GetComponent<Rigidbody2D>();
			if(rb != null && rb.tag == "Enemy")
			{
				// Enemy script 스크립트를 찾고 몬스터의 생명력을 0으 만들자.
				rb.gameObject.GetComponent<Enemy>().HP = 0;
				
				// bomb으로부터 enemy 까지의 벡터를 구하자 
				Vector3 deltaPos = rb.transform.position - transform.position;
				
				// bombForce의 크기만큼 힘의 방향을 적용 
				// normalized는 벡터를 단위 벡터로 정규화
				Vector3 force = deltaPos.normalized * bombForce;
				rb.AddForce(force);
			}
		}
		
		// 씬에 explosionParticle 오브젝트의 position을 bomb의 position으로 셋팅한다음 particle system 플레이
		explosionFX.transform.position = transform.position;
		explosionFX.Play();
		
		// explosion prefab 생성
		Instantiate(explosion,transform.position, Quaternion.identity);
		
		// 폭발 사운드 이팩트 Play
		AudioSource.PlayClipAtPoint(boom, transform.position);
		
		// bomb 오브젝트 파괴 
		Destroy (gameObject);
	}
}
