using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 touchPos;
    private Camera Camera;
    private float MaxDistance = 15f;
    public AudioClip[] add;

    AudioSource MyAudio;

    //인벤토리구현
    private Inventory inventory;
    public GameObject itemButton;
    //아이템획득구현
    public Sprite item;

    void Start()
    {
        Camera = GetComponent<Camera>();
        MyAudio = GetComponent<AudioSource>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();//인벤토리 컴포넌트연결
    }


    void Update()
    {

        //raycast를 이용한 터치-충돌 구현

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)

        {

            MyAudio.clip = add[Random.Range(0, 2)];
            MyAudio.Play();

            touchPos = Input.mousePosition;

            touchPos = Camera.ScreenToWorldPoint(touchPos);



            RaycastHit2D hit = Physics2D.Raycast(touchPos, transform.forward, MaxDistance);

           // Debug.DrawRay(touchPos, transform.forward * 10, Color.red, 0.3f); RAY에 색깔입히기

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")

                {
                    MyAudio.clip = add[2];
                    MyAudio.Play();

                    hit.transform.GetComponent<Enemy>().isDead = true; //기능 구현 Die 상태로 변환 애니메이션 후 객체파괴


                }
                //아이템 획득 구현

                if (hit.collider.tag == "Item")
                {
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (inventory.isFull[i] == false)
                        {
                            inventory.isFull[i] = true; //아이템 추가
                            Instantiate(itemButton, inventory.slots[i].transform, false);//인벤토리 위치에 아이템버튼 표시
                            item = hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite;//충돌한 아이템 스프라이트가져오기

                            Destroy(hit.transform.gameObject);//획득한 아이템 제거
                            break;
                        }
                    }
                }
            }
        }

        
        /*if (Input.touchCount>0)

        {

            touchPos = Input.GetTouch(0).position;    // 터치한 위치

            Ray ray = Camera.main.ScreenPointToRay(touchPos);    // 터치한 좌표 레이로 바꾸엉

            RaycastHit hit;    // 정보 저장할 구조체 만들고

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))    // 레이저를 끝까지 쏴블자. 충돌 한넘이 있으면 return true다.

            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)    // 딱 처음 터치 할때 발생한다

                {
                    if (hit.collider.CompareTag("Enemy"))
                        {
                             //애니메이션 Die state 로 넘어가게
                        }


                    }
                }
            } 
    
        }*/   //모바일구현예 

    }
}
