using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private int randSpawn;
    private int randSprite;

    public Sprite[] Sprite_Pic;
    public GameObject Item;

    //스폰위치 랜덤
    private float randomX;
    private float randomY;
    
    
    

    void Start()
    {

        InvokeRepeating("Spawnitem", 0, 4); //0초후에 3초마다 Spawnitem()를 호출한다.

    }



    void Spawnitem()

    {
        if (Score.scoreValue < 500)
        {
            gameObject.GetComponent<ItemSpawner>().enabled = false;

        }

        else if(Score.scoreValue>=500&& Score.scoreValue < 3000)
        {
            gameObject.GetComponent<ItemSpawner>().enabled = true;

            randomX = Random.Range(-2.8f, 2.8f);
            randomY = Random.Range(-3.4f, 4.5f);
            randSpawn = Random.Range(0, 3);//수정해라 5로

            if (randSpawn < 1)

            {

                Debug.Log("생성");
                //아이템 스프라이트 랜덤
                randSprite = Random.Range(0, Sprite_Pic.Length-2);
                Item.GetComponent<SpriteRenderer>().sprite = Sprite_Pic[randSprite];


                GameObject item = (GameObject)Instantiate(Item, new Vector3(randomX, randomY, 0f), Quaternion.identity);

            }
        }
        else if(Score.scoreValue >= 3000 && Score.scoreValue < 10000)
        {
            gameObject.GetComponent<ItemSpawner>().enabled = true;

            randomX = Random.Range(-2.8f, 2.8f);
            randomY = Random.Range(-3.4f, 4.5f);
            randSpawn = Random.Range(0, 3);//수정해라 5로

            if (randSpawn < 1)

            {

                Debug.Log("생성");
                //아이템 스프라이트 랜덤
                randSprite = Random.Range(0, Sprite_Pic.Length-1);
                Item.GetComponent<SpriteRenderer>().sprite = Sprite_Pic[randSprite];


                GameObject item = (GameObject)Instantiate(Item, new Vector3(randomX, randomY, 0f), Quaternion.identity);

            }
        }
        else
        {
            gameObject.GetComponent<ItemSpawner>().enabled = true;

            randomX = Random.Range(-2.8f, 2.8f);
            randomY = Random.Range(-3.4f, 4.5f);
            randSpawn = Random.Range(0, 3);//수정해라 5로

            if (randSpawn < 1)

            {

                Debug.Log("생성");
                //아이템 스프라이트 랜덤
                randSprite = Random.Range(0, Sprite_Pic.Length);
                Item.GetComponent<SpriteRenderer>().sprite = Sprite_Pic[randSprite];


                GameObject item = (GameObject)Instantiate(Item, new Vector3(randomX, randomY, 0f), Quaternion.identity);

            }
        }

        //기존 해금없는 구현

        /*
        //스폰위치 랜덤
        randomX = Random.Range(-2.8f, 2.8f);
        randomY = Random.Range(-3.4f, 4.5f);
        randSpawn = Random.Range(0, 1);//수정해라 5로

        if (randSpawn<1)

        {

            Debug.Log("생성");
            //아이템 스프라이트 랜덤
            randSprite = Random.Range(0, Sprite_Pic.Length);
            Item.GetComponent<SpriteRenderer>().sprite = Sprite_Pic[randSprite];
       

            GameObject item = (GameObject)Instantiate(Item, new Vector3(randomX, randomY, 0f), Quaternion.identity);

        }
        */
    }

}

