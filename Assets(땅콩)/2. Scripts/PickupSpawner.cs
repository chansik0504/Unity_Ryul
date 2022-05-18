using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
	public GameObject[] pickups;				// 첫 번째 픽업할 폭탄과 두 번째 라이프를 저장하는 픽업프리팹 배열 
	public float pickupDeliveryTime = 5f;		// 배달의 딜레이 
	public float dropRangeLeft;					// 배달이 발생 할 수있는 월드좌표(world coordinates) x 의 최소값 
	public float dropRangeRight;				// 배달이 발생 할 수있는 월드좌표(world coordinates) x 의 최대값 
	public float highLifeThreshold = 75f;		// 플레이어의 라이프가 이 변수보다 높으면 오직 폭탄상자만이 배달 될 것이다.
	public float lowHealthThreshold = 25f;		// 플레이어의 라이프가 이 변수보다 낮으면 오직 라이프상자만이 배달 될 것이다.

	
	private PlayerLife playerLife;			// PlayerLife script를 위한 레퍼런스 
	
	
	void Awake ()
	{
		// 레퍼런스(참조)들을 셋팅.
		playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
	}
	
	
	void Start ()
	{
		// 첫 배달을 시작 
		StartCoroutine(DeliverPickup());
	}
	
	
	public IEnumerator DeliverPickup()
	{
		// 배달 딜레이를 위해 기달리자 
		yield return new WaitForSeconds(pickupDeliveryTime);
		
		// drop 범위 안에 배달을 위한 랜덤 X 좌표를 만들자. 
		float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);
		
		// 랜덤 X 좌표로 position을 생성 
		Vector3 dropPos = new Vector3(dropPosX, 15f, 1f);
		
		// 만약 플레이어의 라이프가 설정한 (high)라이프 한계점 보다 크다면... 
		if(playerLife.life >= highLifeThreshold)
			// drop position에 픽업할 폭탄을 생성하자 
			Instantiate(pickups[0], dropPos, Quaternion.identity);
		// 그렇지 않고 만약 플레이어의 라이프가 설정한 (low)라이프 한계점 보다 작다면... 
		else if(playerLife.life <= lowHealthThreshold)
			// drop position에 픽업할 라이프를 생성하자 
			Instantiate(pickups[1], dropPos, Quaternion.identity);
		// 그렇지 않으면...
		else
		{
			// drop position에 랜덤 픽업객체를 생성  
			int pickupIndex = Random.Range(0, pickups.Length);
			Instantiate(pickups[pickupIndex], dropPos, Quaternion.identity);
		}
	}
}
