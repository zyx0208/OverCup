using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerHP;
    public int stage;
    public TMP_Text stage_info_text;
    public TMP_Text playerHP_info_text;

    void Start()
    {
        playerHP = 10; //플레이어의 체력 설정
        stage = 1; //1라운드부터 시작
        //stage_text = GameObject.Find("stage_text").GetComponent<Text>(); //스테이지 정보를 나타내는 텍스트를 찾기
        stage_info_text.text = "Stage : " + stage.ToString(); //모든 자료형이 String이어야 하므로, .ToString()사용
        playerHP_info_text.text = "HP : " + playerHP.ToString();
    }

    void Update()
    {
        
    }

    public void Damage(int val) //몬스터를 물리치지 못해서, 몬스터가 길 끝까지 도달했을 때
    {
        playerHP = playerHP - val;
        playerHP_info_text.text = "HP : " + playerHP.ToString();
    }
    public void Log_HP()
    {
        Debug.Log("플레이어의 체력 : " + playerHP);
    }
    public void Stage_Clear() //스테이지를 클리어 했을 때
    {
        Debug.Log("스테이지 클리어!");
        stage++;
        stage_info_text.text = "Stage : " + stage.ToString();
        Debug.Log("현재 스테이지 : " + stage);
    }
    public void Log_Stage()
    {
        Debug.Log("현재 스테이지 : " + stage);
    }
}
