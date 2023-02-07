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
        playerHP = 10; //�÷��̾��� ü�� ����
        stage = 1; //1������� ����
        //stage_text = GameObject.Find("stage_text").GetComponent<Text>(); //�������� ������ ��Ÿ���� �ؽ�Ʈ�� ã��
        stage_info_text.text = "Stage : " + stage.ToString(); //��� �ڷ����� String�̾�� �ϹǷ�, .ToString()���
        playerHP_info_text.text = "HP : " + playerHP.ToString();
    }

    void Update()
    {
        
    }

    public void Damage(int val) //���͸� ����ġ�� ���ؼ�, ���Ͱ� �� ������ �������� ��
    {
        playerHP = playerHP - val;
        playerHP_info_text.text = "HP : " + playerHP.ToString();
    }
    public void Log_HP()
    {
        Debug.Log("�÷��̾��� ü�� : " + playerHP);
    }
    public void Stage_Clear() //���������� Ŭ���� ���� ��
    {
        Debug.Log("�������� Ŭ����!");
        stage++;
        stage_info_text.text = "Stage : " + stage.ToString();
        Debug.Log("���� �������� : " + stage);
    }
    public void Log_Stage()
    {
        Debug.Log("���� �������� : " + stage);
    }
}
