using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyPrefab;
    //생선된 Enemy관리 위한 리스트
    GameObject[] list = new GameObject[50];

    GameObject temp;

    //스폰위치 랜덤
    private float randomX;
    private float randomY;
    //List 배열 Null인지 체크
    private int i;

    void Start()
    {

        InvokeRepeating("SpawnEnemy", 0, 1f); //0초후에 0.5초마다 SpawnEnemy()를 호출한다.

    }
    
    /*
    void Update()
    {
       
        //리스트로 만들려다 망함
        
        for (i = list.Count-1; i >= 0 ; i--)
        {
            if (list[i].activeSelf == false || list[i] == null )
            {
                list.RemoveAt(i);
            }
        }
        
    }
    */

    void SpawnEnemy()
    {
        randomX = Random.Range(-4.5f, 4f);
        randomY = Random.Range(-3.5f, 5f);

        if (Enemy.EnemyNum < 50)
        {
            temp = Instantiate(EnemyPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);

            for (i = 0; i < 50; i++)
            {
                if (list[i] == null)
                {
                    list[i] = temp;
                }
            }

        }

        //리스트로 만들려다 망함
        /*
         if (list.Count < 5)
         {
             list.Add(Instantiate(Enemy, new Vector3(randomX, randomY, 0f), Quaternion.identity));
         }
         */
    }
}
