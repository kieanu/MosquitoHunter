using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;//0으로 수정하셈
    public static int scoreAds = 1;//광고시청시 3배
    public static bool isAdsActive = false;//광고리워드 키고끄기
    private float Adstime=0f;

    Text score;

    void Start()
    {
        score = GetComponent<Text>();
        scoreValue = PlayerPrefs.GetInt("Sum");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "CatchScore" + PlayerPrefs.GetInt("Sum");// 누적스코어를 표시하기위해 scoreValue가아닌 playerPrefs 정보가 필요하고 변수에 저장하여 계속가산

        if(isAdsActive == true)
        {
            scoreAds = 3;
            Adstime += Time.deltaTime;
            if (Adstime > 20f)
            {
                Adstime = 0f;
                isAdsActive = false;
                scoreAds = 1;
            }
        }
    }
}
