using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int num;
    public float speed;
    private int flip; //이미지 플립확률 조정
    

    private Animator animator;
    public AudioSource audioSource;
    public AudioClip Buzz;

    public SpriteRenderer rend;
    public bool isDead = false; //Ray에서 사망여부 판단
    private int stopAnime = 0;
    //에너미 갯수 제한
    public static int EnemyNum;
    //피튀는효과
    public GameObject blood;

    void Start()
    {
        EnemyNum++;

        audioSource = GetComponent<AudioSource>(); //모기소리 삽입
        audioSource.clip = Buzz;
        
        audioSource.Play();

        rend = GetComponentInChildren<SpriteRenderer>(); //이미지 반전을 위한 렌더러 삽입
        animator = GetComponent<Animator>();
        speed = Random.Range(0f, 5f); //모기 속도 임의로 지정되도록 상수지정;
    }

   
    void Update()
    {
        //모기 AI 구현
        num = Random.Range(1, 5);
        flip = Random.Range(1, 10);

        if (num == 1)
        {
            transform.position = transform.position + new Vector3(3.0f*speed*Time.deltaTime, 0f, 0f);
            if (flip == 3)
            {
                rend.flipX = false;
            }
        }
        if (num == 2)
        {
            transform.position = transform.position + new Vector3(-3.0f*Time.deltaTime * speed, 0f, 0f);
            if (flip == 3)
            {
                rend.flipX = true;
            }
        }
        if (num == 3)
        {
            transform.position = transform.position + new Vector3(0f, 3.0f * Time.deltaTime * speed, 0f);
        }
        if (num == 4)
        {
            transform.position = transform.position + new Vector3(0f, -3.0f * Time.deltaTime * speed, 0f);
        }

        if(isDead && stopAnime == 0)
        {
            EnemyNum -= 1;
            PlayerPrefs.SetInt("Sum", PlayerPrefs.GetInt("Sum") + 1*Score.scoreAds);

            Score.scoreValue += (1 * Score.scoreAds);//점수 1점추가

            //피튀기는 효과
            Instantiate(blood, transform.position, Quaternion.identity);
           
            //애니메이션대신 피튀기기
            //animator.SetTrigger("Die");

            stopAnime++;
            Destroy(gameObject);
        }
      
    }

}
