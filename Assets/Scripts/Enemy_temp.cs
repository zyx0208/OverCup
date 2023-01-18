using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_temp : MonoBehaviour
{
    public int speed; //ĳ������ �̵��ӵ�
    public int HP; //ĳ������ ü��
    public GameObject GM; //�÷��̾��� HP�� �����ϱ� ���� ���
    Vector2 direction;

    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(-5.4f, 1.8f, 0f); //�� ���� ���� ����
        direction = new Vector2(1f, 0f);
        GM = GameObject.Find("GameManager"); //���� �� ������ ������ �� ���� ������, ���� �Ŵ������ �̸��� �޾ƿ�

        //HP���� �ڵ� �߰� ����
        HP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //�� �̵� �ڵ�
        this.transform.Translate(direction * speed * Time.deltaTime);
        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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

        if (collision.tag == "End")
        {
            GM.GetComponent<GameManager>().Damage(1);
            GM.GetComponent<GameManager>().Log_HP();
            Destroy(this.gameObject);
        }
    }
}
