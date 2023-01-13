using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_temp : MonoBehaviour
{
    public int speed; //캐릭터의 이동속도
    private int road_type; //캐릭터 이동을 위한 변수
    
    void Start()
    {
        road_type = 0;
        gameObject.GetComponent<Transform>().position = new Vector3(-5.4f, 1.8f, 0f); //몹 생성 지점 설정
    }

    // Update is called once per frame
    void Update()
    {
        //몹 이동 코드
        if(road_type == 0)
        {
            this.transform.Translate(new Vector2(1f, 0f) * speed * Time.deltaTime);
            if(this.transform.position.x >= 5.4f)
            {
                road_type++;
            }
        }
        else if (road_type == 1)
        {
            this.transform.Translate(new Vector2(0f, 1f) * speed * Time.deltaTime);
            if (this.transform.position.y >= 5.4f)
            {
                road_type++;
            }
        }
        else if (road_type == 2)
        {
            this.transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
            if (this.transform.position.x <= 1.8f)
            {
                road_type++;
            }
        }
        else if (road_type == 3)
        {
            this.transform.Translate(new Vector2(0f, -1f) * speed * Time.deltaTime);
            if (this.transform.position.y <= -5.4f)
            {
                road_type++;
            }
        }
        else if (road_type == 4)
        {
            this.transform.Translate(new Vector2(1f, 0f) * speed * Time.deltaTime);
            if (this.transform.position.x >= 5.4f)
            {
                road_type++;
            }
        }
        else if (road_type == 5)
        {
            this.transform.Translate(new Vector2(0f, 1f) * speed * Time.deltaTime);
            if (this.transform.position.y >= -1.8f)
            {
                road_type++;
            }
        }
        else if (road_type == 6)
        {
            this.transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
            if (this.transform.position.x <= -5.4f)
            {
                road_type++;
            }
        }
        else if (road_type == 7)
        {
            this.transform.Translate(new Vector2(0f, -1f) * speed * Time.deltaTime);
            if (this.transform.position.y <= -5.4f)
            {
                road_type++;
            }
        }
        else if (road_type == 8)
        {
            this.transform.Translate(new Vector2(1f, 0f) * speed * Time.deltaTime);
            if (this.transform.position.x >= -1.8f)
            {
                road_type++;
            }
        }
        else if (road_type == 9)
        {
            this.transform.Translate(new Vector2(0f, 1f) * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "End")
        {
            Destroy(this.gameObject);
        }
    }
}
