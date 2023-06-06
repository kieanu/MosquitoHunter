using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image 등의UI관련 변수 등을 사용할수 있게됩니다

public class ItemButton : MonoBehaviour
{

    private Sprite sprite;//조건문 구현
    GameObject[] delete;

    private int i;
    private int length;
    public GameObject FieldShield;

    void Start()
    {
        Player item = GameObject.Find("Main Camera").GetComponent<Player>();
        gameObject.GetComponent<Image>().sprite = item.item;
        sprite = gameObject.GetComponent<Image>().sprite;//조건문 구현

    }

    public void Use()
    {
        if (Time.timeScale != 0f)
        {

            //if(sprite.name=="fire")문으로 스프라이트 이름별 기능구현
            if (sprite.name == "Fire")
                {
                    Destroy(gameObject);

                    delete = GameObject.FindGameObjectsWithTag("Enemy");
                    length = GameObject.FindGameObjectsWithTag("Enemy").Length;

                    for (i=0;i<length;i++)
                    {
                        delete[i].GetComponent<Enemy>().isDead = true;
                    }
                    
                }

            else if (sprite.name == "field")
            { 
                Destroy(gameObject);

                Destroy(Instantiate(FieldShield, new Vector3(0f, 0f, 0f), Quaternion.identity),5f);

                delete = GameObject.FindGameObjectsWithTag("Enemy");
                length = GameObject.FindGameObjectsWithTag("Enemy").Length;
                
                for (i = 0; i < length; i++)
                {
                    delete[i].transform.position = new Vector3(0, 0, 0);
                }

            }

            else if(sprite.name == "Smoke")
            {
                Destroy(gameObject);

                delete = GameObject.FindGameObjectsWithTag("Enemy");
                length = GameObject.FindGameObjectsWithTag("Enemy").Length;

                for (i = 0; i < length; i++)
                {
                    delete[i].GetComponent<Enemy>().speed = (delete[i].GetComponent<Enemy>().speed / 2);
                }

            }

            else
            {
                Debug.Log("ERROR");
            }


        } 
          
    }


    //gameObject.GetComponent<Image>().sprite
    //기능구현필요 아이템버튼의 이미지위치가inventory[i]의 위치와 같을때 아이템 버튼 클릭시 inventory[i].isFull을 false로 초기화하기
    //이미지에따른 기능구현필요
}
