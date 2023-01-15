using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_temp : MonoBehaviour
{
    public int speed; //ĳ������ �̵��ӵ�
    private int road_type; //ĳ���� �̵��� ���� ����
    Vector2 direction;

    void Start()
    {
        road_type = 0;
        gameObject.GetComponent<Transform>().position = new Vector3(-5.4f, 1.8f, 0f); //�� ���� ���� ����
        direction = new Vector2(1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //�� �̵� �ڵ�
        this.transform.Translate(direction * speed * Time.deltaTime);
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
            Destroy(this.gameObject);
        }
    }
}
