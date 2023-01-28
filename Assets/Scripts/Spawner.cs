using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Respawn_time = 1f; //n�ʸ��� ���� ��ȯ
    public GameObject Enemy;
    float timer;
    int monster_num; //���帶�� ��ȯ�Ǵ� ������ ��
    public int dead_moster_num; //���� Ŭ��� Ȯ���ϱ� ���� ���Ͱ� ���� ����
    int count; //���͸� ��� ��ȯ�ߴ��� üũ�ϱ� ���� ����
    
    //�������� Ŭ���� �� Invoke()�� ���� �ð� ������ ���� ���� �Լ� ����
    void stage_setting() //�Ϲ��� ����
    {
        count = 0;
    }
    void boss_stage_setting() //������ ����
    {
        count = monster_num - 1;
    }

    void Start()
    {
        monster_num = 20; //���⼭ ������ ��(n) ����
        dead_moster_num = monster_num;
        count = 0;
        timer = Respawn_time;
    }

    // Update is called once per frame
    void Update()
    {
        //���͸� n������ŭ ��ȯ��Ű�� �ڵ�
        if(count < monster_num)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                count++;
                timer = Respawn_time;
                Instantiate(Enemy);
            }
        }
        //���� n������ ���Ͱ� ������ �������� Ŭ����
        if(dead_moster_num == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Stage_Clear();
            if(GameObject.Find("GameManager").GetComponent<GameManager>().stage % 10 == 0) //������ ���
            {
                dead_moster_num = 1; 
                Invoke("boss_stage_setting", 5f); //�������� Ŭ���� �� ��� �ð� ����
            }
            else //�Ϲ� ������ ���
            {
                dead_moster_num = monster_num;
                Invoke("stage_setting", 5f); //�������� Ŭ���� �� ��� �ð� ����
            }
            
        }
    }
}
