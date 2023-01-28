using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHP;
    public int stage;

    void Start()
    {
        playerHP = 10; //플레이어의 체력 설정
        stage = 1; //1라운드부터 시작
    }

    void Update()
    {
        
    }

    public void Damage(int val)
    {
        playerHP = playerHP - val;
    }
    public void Log_HP()
    {
        Debug.Log("플레이어의 체력 : " + playerHP);
    }
    public void Stage_Clear()
    {
        Debug.Log("스테이지 클리어!");
        stage++;
        Debug.Log("현재 스테이지 : " + stage);
    }
    public void Log_Stage()
    {
        Debug.Log("현재 스테이지 : " + stage);
    }
}
