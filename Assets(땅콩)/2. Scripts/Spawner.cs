using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f;		// 각 spawn 사이에 시간의 양 (딜레이 타임)
	public float spawnDelay = 3f;		// spawn을 시작하기 전에 시간의 양 (딜레이 타임)
	public GameObject[] enemies;		// enemy 프리팹들을 저장할 수 있는 배열
	
	
	void Start ()
	{
		// 다음 함수의 호출로 일정 딜레이 이후 주기적으로 Spawn함수의 호출을 시작한다   
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	
	void Spawn ()
	{
		// 랜덤 enemy객체를 생성(인스턴스화)
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
		
		// 해당 객체를 포함하여 하위로 모든 Particle System 컴포넌트를 찾아와 spawning effect를 플레이       
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}