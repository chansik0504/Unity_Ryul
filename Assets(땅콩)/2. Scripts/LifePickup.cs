using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
	public float lifeBonus;				// 얼마나 많은 라이프를 상자가 플레이어게 줄지... 설정 변수 
	public AudioClip collect;				// 상자를 흭득했을때의 사운드  
	
	
	private PickupSpawner pickupSpawner;	// PickupSpawner을 위한 레퍼런스 
	private Animator anim;					// animator component를 위한 레퍼런스 
	private bool landed;					// 상자가 땅에 있는지 아닌지를 위한 변수 
	
	
	void Awake ()
	{
		// 레퍼런스(참조)들을 셋팅.
		pickupSpawner = GameObject.Find("PickupSpawner").GetComponent<PickupSpawner>();
		anim = transform.root.GetComponent<Animator>();
	}
	
	
	void OnTriggerEnter2D (Collider2D other)
	{
		// 만약 플레이어가 trigger zone에 들어왔을경우...
		if(other.tag == "Player")
		{
			// PlayerLife script를 위한 레퍼런스를 얻자.
			PlayerLife playerLife = other.GetComponent<PlayerLife>();
			
			// 플레이어의 라이프를 lifeBonus에 의해서 증가시키자 그러나 라이프가 100이상 증가해도 라이프를 100으로 고정시키자 
			playerLife.life += lifeBonus;
			playerLife.life = Mathf.Clamp(playerLife.life, 0f, 100f);
			
			// LifeBar를 Update 하자 
			playerLife.UpdateLifeBar();
			
			// 새로운 배달을 작동시키자.
			pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());
			
			// 상자 흭득 사운드 Play
			AudioSource.PlayClipAtPoint(collect,transform.position);
			
			// 상자 Destroy
			Destroy(transform.root.gameObject);
		}
		// 그렇지 않고 만약 상자가 땅에 착륙 했을때...
		else if(other.tag == "ground" && !landed)
		{
			// animator의 trigger parameter를 Land로 셋팅 
			anim.SetTrigger("Land");
			
			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;	
		}
	}
}
