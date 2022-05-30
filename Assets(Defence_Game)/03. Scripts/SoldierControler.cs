using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(AudioSource))]

public class SoldierControler : MonoBehaviour
{

    // [HideInInspector]
    //죽었는지 상태변수 
    public bool isDie;

    //적과의 거리를 위한 변수
    public float dist1;
    public float dist2;

    //Enemy를 찾기 위한 배열 
    private GameObject[] Enemys;
    private Transform EnemyTarget;

    //자신의 Transform 참조 변수  
    private Transform myTr;

    // 회전의 중심축
    public Transform targetTr;

    // 터렛 발사 변수
    private bool shot;
    // 적을 봐라보는 회전 속도
    private float enemyLookTime;
    //적을 봐라보는 회전각
    private Quaternion enemyLookRotation;

    //Ch7
    //테스트용 변수
    public Texture test;

    //총탄 프리팹을 위한 레퍼런스
    public GameObject bullet;
    //총탄의 발사 시작 좌표 연결 변수 
    public Transform firePos;
    //총알 발사 주기
    private float bulletSpeed;
    //AudioSource 컴포넌트 저장할 레퍼런스 
    private AudioSource source = null;
    //MuzzleFlash GameObject를 연결 할 레퍼런스 
    public GameObject muzzleFlash;
    //총탄의 발사 사운드 
    public AudioClip fireSfx;

    //Ray 정보 저장 구조체 
    Ray ray;
    // Ray에 맞은 오브젝트 정보를 저장 할 구조체
    RaycastHit hitInfo;
    //Ray 센서를 위한 변수
    bool check;

    //레이저 발사를 위한 컴포넌트
    public LineRenderer rayLine;

    //레이저 도트 타겟을 위한 변수
    public Transform rayDot;


    public Animator _anim;
    //NavMeshAgent 컴포넌트 할당 레퍼런스 
    private NavMeshAgent myTraceAgent;

    //케릭이 이동할 목적지 좌표
    Vector3 movePoint = Vector3.zero;

    // Ray에 맞은 오브젝트 정보를 저장 할 구조체
    Ray ray1;
    RaycastHit hitInfo1;

    void Awake()
    {
        //NavMeshAgent 컴포넌트를 해당 레퍼런스에 연결
        myTraceAgent = GetComponent<NavMeshAgent>();
        //nvAgent.isStopped = true; //네비게이션 멈춤 
        //nvAgent.velocity = Vector3.zero; //네비게이션 멈춤   

        bullet = (GameObject)Resources.Load("Base/Bullet", typeof(GameObject));
        test = (Texture)Resources.Load("Base/Bullet", typeof(Texture));
        fireSfx = Resources.Load<AudioClip>("Base/bazooka");



        //자기 자신의 Transform 연결
        myTr = GetComponent<Transform>();

        //AudioSource 컴포넌트를 해당 변수에 할당
        source = GetComponent<AudioSource>();
        //처음에 MuzzleFlash 를 비활성화  
        muzzleFlash.SetActive(false);
    }

    public void StartBase()
    {
        Debug.Log("StartBase");

        // 일정 간격으로 주변의 가장 가까운 Enemy를 찾는 코루틴 
        StartCoroutine(this.TargtSetting());

        // 가장 가까운 적을 찾아 발사...
        StartCoroutine(this.ShotSetting());

    }


        // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (1.0f >= Mathf.Abs(transform.position.x - movePoint.x + transform.position.y - movePoint.y))
        {

            _anim.SetBool("Run", false);
        }



#if UNITY_EDITOR
        //마우스 왼쪽 버튼을 클릭시 Ray를 캐스팅  
        if (Input.GetMouseButtonDown(0) && !isDie)
        {
            _anim.SetBool("Run", true);
            
            //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Barrel 일때만 충돌)
            // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
            if (Physics.Raycast(ray1, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Barrel")))
            {
                //ray에 맞은 위치를 이동할 목표지점으로 설정
                movePoint = hitInfo1.point;

                //NavMeshAgent 컴포넌트의 목적지 설정
                myTraceAgent.destination = movePoint;
                myTraceAgent.stoppingDistance = 25.0f;
            }
            //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Ground 일때만 충돌)
            // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
            else if (Physics.Raycast(ray1, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                //ray에 맞은 위치를 이동할 목표지점으로 설정
                movePoint = hitInfo1.point;

                //NavMeshAgent 컴포넌트의 목적지 설정
                myTraceAgent.destination = movePoint;
                myTraceAgent.stoppingDistance = 0.0f;
            }
        }
#endif

#if UNITY_STANDALONE_WIN
            //마우스 왼쪽 버튼을 클릭시 Ray를 캐스팅  
            if (Input.GetMouseButtonDown(0) && !isDie)
            {
                //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Barrel 일때만 충돌)
                // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
                if (Physics.Raycast(ray, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Barrel")))
                {
                    //ray에 맞은 위치를 이동할 목표지점으로 설정
                    movePoint = hitInfo1.point;

                    //NavMeshAgent 컴포넌트의 목적지 설정
                    myTraceAgent.destination = movePoint;
                    myTraceAgent.stoppingDistance = 25.0f;

                }
                //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Ground 일때만 충돌)
                // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
                else if (Physics.Raycast(ray, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
                {
                    //ray에 맞은 위치를 이동할 목표지점으로 설정
                    movePoint = hitInfo1.point;

                    //NavMeshAgent 컴포넌트의 목적지 설정
                    myTraceAgent.destination = movePoint;
                    myTraceAgent.stoppingDistance = 0.0f;

                }
            }
#endif

#if UNITY_ANDROID
        //스크린에 터치가 이루어진 상태에서 첫 번째 손가락 터치가 시작됐는지 비교
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isDie)
        {
            //Main Camera에서 손가락 터치 위치로 캐스팅되는 Ray를 생성 함
            ray1 = Camera.main.ScreenPointToRay(Input.touches[0].position);

            //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Barrel 일때만 충돌)
            // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
            if (Physics.Raycast(ray1, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Barrel")))
            {
                //ray에 맞은 위치를 이동할 목표지점으로 설정
                movePoint = hitInfo1.point;

                //NavMeshAgent 컴포넌트의 목적지 설정
                myTraceAgent.destination = movePoint;
                myTraceAgent.stoppingDistance = 25.0f;
            }
            //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리, 레이어 마스크 값(레이어가 Ground 일때만 충돌)
            // Mathf.Infinity 이 값은 무한한 값이라고 생각하면 된다. 따라서 거리가 무한~~~
            else if (Physics.Raycast(ray1, out hitInfo1, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                //ray에 맞은 위치를 이동할 목표지점으로 설정
                movePoint = hitInfo1.point;

                //NavMeshAgent 컴포넌트의 목적지 설정
                myTraceAgent.destination = movePoint;
                myTraceAgent.stoppingDistance = 0.0f;
            }

        }

        //ray 정보 업데이트
        ray.origin = firePos.position;
        // firePos local space(앞 방향)를 world space로 변환 
        ray.direction = firePos.TransformDirection(Vector3.forward);

        //Scene 뷰에만 시각적으로 표현함
        Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.green);


//        Debug.Log(hitInfo1.collider.tag);
        //위에서 미리 생성한 ray를 인자로 전달, out(메서드 안에서 메서드 밖으로 데이타를 전달 할때 사용)hit, ray 거리
        if (Physics.Raycast(ray, out hitInfo, 30.0f))
        {

            // hitInfo.point 는 월드좌표이다 따라서 로컬 좌표로 변환
            Vector3 posValue = firePos.InverseTransformPoint(hitInfo.point);
            //타겟 거리체크 레이저 생성
            rayLine.SetPosition(0, posValue);
            //타겟에 레이저 Dot 생성 
            rayDot.localPosition = posValue;

            if (shot && hitInfo.collider.tag == "Enemy")
            {
                //발사를 위한 변수 true
                Debug.Log("Hi");
                check = true;
            }


        }
        else
        {
            //기본 거리체크 레이저 생성
            rayLine.SetPosition(0, new Vector3(0, 0, 30.0f));

            //타겟에 레이저 Dot 초기화 
            rayDot.localPosition = Vector3.zero;

        }



        if (!shot)
        {

            myTr.RotateAround(targetTr.position, Vector3.up, Time.deltaTime * 55.0f);
            //transform.RotateAroundLocal(Vector3.up, Time.deltaTime * 55.0f);

            //발사를 위한 변수 false
            check = false;
        }
        else
        {
            //적을 봐라봄  
            if (shot)
            {
                if (Time.time > enemyLookTime)
                {

                    //	enemyLookRotation = Quaternion.LookRotation(-(EnemyTarget.forward)); // - 해줘야 바라봄  
                    enemyLookRotation = Quaternion.LookRotation(EnemyTarget.position - myTr.position); // - 해줘야 바라봄  
                    myTr.rotation = Quaternion.Lerp(myTr.rotation, enemyLookRotation, Time.deltaTime * 2.0f);
                    enemyLookTime = Time.time + 0.01f;
                }
            }
        }



        //만약 발사가 true 이면....
        if (shot && check)
        {
            if (Time.time > bulletSpeed)
            {
                Debug.Log("ShotStart");
                //일정 주기로 발사
                ShotStart();
                bulletSpeed = Time.time + 0.3f;
            }
        }
#endif
    }


    IEnumerator TargtSetting()
    {

        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            // 자신과 가장 가까운 플레이어 찾음
            Enemys = GameObject.FindGameObjectsWithTag("EnemyBody");
            Transform EnemyTargets = Enemys[0].transform;
            float dist = (EnemyTargets.position - myTr.position).sqrMagnitude;
            foreach (GameObject _Enemy in Enemys)
            {
                if ((_Enemy.transform.position - myTr.position).sqrMagnitude < dist)
                {
                    EnemyTargets = _Enemy.transform;
                    dist = (EnemyTargets.position - myTr.position).sqrMagnitude;
                }
            }


            EnemyTarget = EnemyTargets;

        }

    }

    // 가장 가까운 적을 찾아 발사...
    IEnumerator ShotSetting()
    {
        Debug.Log("발싸");

        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            // 여기선 불 필요
            dist2 = (EnemyTarget.position - myTr.position).sqrMagnitude;
            // dist2 = Vector3.Distance(myTr.position, EnemyTarget.position);


            // 체크후 발사 지정... 코루틴으로 처리가 더 효율
            if (dist2 < 500.0f)
            {
                shot = true;
            }
            else
            {
                shot = false;

            }


        }

    }


    //터렛 발사
    private void ShotStart()
    {
        //잠시 기다리는 로직처리를 위해 코루틴 함수로 호출
        StartCoroutine(this.FireStart());
    }

    // 총탄 발사 코루틴 함수
    IEnumerator FireStart()
    {
        //Debug.Log("Fire");
        //Bullet 프리팹을 동적 생성
        Instantiate(bullet, firePos.position, firePos.rotation);

        //총탄 사운드 발생 
        source.PlayOneShot(fireSfx, fireSfx.length + 0.2f);

        //MuzzleFlash 스케일을 불규칙하게 하자 
        float scale = Random.Range(1.0f, 2.5f);
        muzzleFlash.transform.localScale = Vector3.one * scale;

        //MuzzleFlash를 Z축으로 불규칙하게 회전시키자 
        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;

        //활성화 시킴
        muzzleFlash.SetActive(true);

        //랜덤 시간 동안 Delay한 다음 MeshRenderer를 비활성화
        yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));

        //비활성
        muzzleFlash.SetActive(false);

    }





    //인스펙터에 스크립트 우 클릭시 컨텍스트 메뉴에서 함수호출 가능
    [ContextMenu("FireStart")]
    void Fire()
    {
        StartBase();
    }

}


// https://docs.unity3d.com/kr/current/Manual/class-NavMeshAgent.html
// https://docs.unity3d.com/kr/current/Manual/class-NavMeshObstacle.html
// https://docs.unity3d.com/kr/current/Manual/class-OffMeshLink.html

// https://docs.unity3d.com/kr/current/Manual/nav-AdvancedSettings.html
// https://docs.unity3d.com/kr/current/Manual/nav-HeightMesh.html