using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // 스테이지
    public int stage;
    // SoundManager 컴포넌트를 연결 할 변수 -> 인스펙터 뷰에는 꼭 필요한 변수만 노출시킴
    private SoundManager _sMgr;
    // 테스트 변수
    public AudioClip soundClip;
    private float soundTime;

    void Awake()
    {
        // SoundManager 게임오브젝트의 SoundManager 컴포넌트 연결
        _sMgr = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        // 배경 사운드 플레이
        _sMgr.PlayBackground(stage);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > soundTime)
        {
            // 3.5초 마다 번개사운드 연출
            LightningSound();

            soundTime = Time.time + 3.5f;
        }
    }

    // 병렬 처리를 위한 코루틴 함수 호출
    void LightningSound()
    {
        // StartCoroutine 으로 Coroutine 함수 호출
        StartCoroutine(this.PlayEffectSound(soundClip));
    }

    // Effect 테스트 사운드를 Coroutine으로 생성
    IEnumerator PlayEffectSound(AudioClip _clip)
    {
        // 공용사운드 함수 호출
        _sMgr.PlayEffct(transform.position, _clip);
        yield return null;
    }
}
