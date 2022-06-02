using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundFile;
    public float soundVolume = 1.0f;
    public bool isSoundMute = false;
    public Slider sl;
    public Toggle tg;
    private AudioSource audio;
    public GameObject Sound;
    public GameObject PlaySoundBtn;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        Debug.Assert(audio);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        soundVolume = sl.value;
        isSoundMute = tg.isOn;
        //PlaySoundBtn.SetActive(true);
        AudioSet();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSound()
    {
        soundVolume = sl.value;
        isSoundMute = tg.isOn;
        AudioSet();
    }

    void AudioSet()
    {
        audio.volume = soundVolume;
        audio.mute = isSoundMute;
    }

    public void SoundUiOpenClose(bool open)
    {
        Sound.SetActive(!open);
        PlaySoundBtn.SetActive(open);
        SaveData();
    }

    
    // public void SoundUiOpen()
    // {
    //     Sound.SetActive(true);
    //     PlaySoundBtn.SetActive(false);
    // }

    // public void SoundUiClose()
    // {
    //     Sound.SetActive(false);
    //     PlaySoundBtn.SetActive(true);
    // }


    public void PlayBackground(int stage)
    {
        // AudioSource의 사운드 연결
        GetComponent<AudioSource>().clip = soundFile[stage-1];
        // AudioSource 셋팅
        AudioSet();
        // 사운드 플레이. Mute 설정시 사운드 안나옴
        GetComponent<AudioSource>().Play();
    }

    public void PlayEffct(Vector3 pos, AudioClip sfx)
    {
        // Mute 옵션 설정 시 이 함수를 바로 빠져나가자.
        if (isSoundMute)
        {
            return;
        }

        // 게임오브젝트의 동적 생성하자.
        GameObject _soundObj = new GameObject("sfx");
        // 사운드 발생 위치 지정하자.
        _soundObj.transform.position = pos;

        // 생성한 게임오브젝트에 AudioSource 컴포넌트를 추가하자.
        AudioSource _audioSource = _soundObj.AddComponent<AudioSource>();
        // AudioSource 속성을 설정
        // 사운드 파일 연결하자.
        _audioSource.clip = sfx;
        // 설정되어있는 볼륨을 적용시키자. 즉, soundvolume으로 게임전체 사운드 볼륨 조절.
        _audioSource.volume = soundVolume;
        // 사운드 3d 셋팅에 최소 범위를 설정하자.
        _audioSource.minDistance = 15.0f;
        // 사운드 3d 셋팅에 최대 범위를 설정하자.
        _audioSource.maxDistance = 30.0f;

        // 사운드를 실행시키자.
        _audioSource.Play();

        // 모든 사운드가 플레이 종료되면 동적 생성된 게임오브젝트 삭제하자.
        Destroy (_soundObj, sfx.length + 0.2f);
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("SOUNDVOLUME", soundVolume);
        // PlayerPrefs 클래스 내부 함수에는 bool형을 저장해주는 함수가 없다.
        // bool형 데이터는 형변환을 해야 PlayerPrefs.SetInt() 함수를 사용가능
        PlayerPrefs.SetInt("ISSOUNDMUTE", System.Convert.ToInt32(isSoundMute));
    }

    public void LoadData()
    {
        sl.value = PlayerPrefs.GetFloat("SOUNDVOLUME");
        tg.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("ISSOUNDMUTE"));

        int isSave = PlayerPrefs.GetInt("ISSAVE");
        if (isSave == 0)
        {
            sl.value = 1.0f;
            tg.isOn = false;
            SaveData();
            PlayerPrefs.SetInt("ISSAVE", 1);
        }
    }
}
