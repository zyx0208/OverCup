using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_temp : MonoBehaviour
{
    public int speed; //������ �̵��ӵ�
    public int HP; //������ ü��
    public GameObject GM; //�÷��̾��� HP�� �����ϱ� ���� ���
    public GameObject spawner; //������ ���� Ƚ���� �����ϱ� ���� ���
    Vector2 direction;

    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(-5.4f, 1.8f, 0f); //�� ���� ���� ����
        direction = new Vector2(1f, 0f);
        GM = GameObject.Find("GameManager"); //���� �� ������ ������ �� ���� ������, ���� �Ŵ������ �̸��� �޾ƿ�
        spawner = GameObject.Find("Spawner"); //������ ������ Ȯ���ϱ� ���� ������ �ڵ� �ҷ�����
        
        //HP���� �ڵ�
        if(GM.GetComponent<GameManager>().stage % 10 == 0) //������ ���
        {
            HP = 10 * GM.GetComponent<GameManager>().stage * 10;
        }
        else //�Ϲ� ������ ���
        {
            HP = 10 * GM.GetComponent<GameManager>().stage; 
        }
        Debug.Log("��� ������ ���� ü�� : " + HP); //�̰� ������ ��
    }

    void Update()
    {
        //�� �̵� �ڵ�
        this.transform.Translate(direction * speed * Time.deltaTime);
        if(HP <= 0)
        {
            spawner.GetComponent<Spawner>().dead_moster_num--;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���Ͱ� ������ ������, ��ϵ� ���� ���� ���� ��ȯ
        if (collision.tag == "Wall")
        {
            if(collision.GetComponent<Change_direction>().changeType == 0)
            {
                direction = new Vector2(0f, 1f);
            }
            else if (collision.GetComponent<Change_direction>().changeType == 1)
            {
                direction = new Vector2(-1f, 0f);
            }
            else if (collision.GetComponent<Change_direction>().changeType == 2)
            {
                direction = new Vector2(0f, -1f);
            }
            else if (collision.GetComponent<Change_direction>().changeType == 3)
            {
                direction = new Vector2(1f, 0f);
            }
        }

        //�� ������ �����ϸ�, �÷��̾�� �������� �԰� �ش� ���� ����
        if (collision.tag == "End")
        {
            GM.GetComponent<GameManager>().Damage(1);
            GM.GetComponent<GameManager>().Log_HP();
            spawner.GetComponent<Spawner>().dead_moster_num--;
            Destroy(this.gameObject);
        }
    }
}
