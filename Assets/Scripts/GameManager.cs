using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHP;
    public int stage;

    void Start()
    {
        playerHP = 10; //�÷��̾��� ü�� ����
        stage = 1; //1������� ����
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
        Debug.Log("�÷��̾��� ü�� : " + playerHP);
    }
    public void Stage_Clear()
    {
        Debug.Log("�������� Ŭ����!");
        stage++;
        Debug.Log("���� �������� : " + stage);
    }
    public void Log_Stage()
    {
        Debug.Log("���� �������� : " + stage);
    }
}
