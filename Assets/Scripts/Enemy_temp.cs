using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_temp : MonoBehaviour
{
    public int speed; //캐릭터의 이동속도
    public int HP; //캐릭터의 체력
    public GameObject GM; //플레이어의 HP를 관리하기 위해 사용
    Vector2 direction;

    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(-5.4f, 1.8f, 0f); //몹 생성 지점 설정
        direction = new Vector2(1f, 0f);
        GM = GameObject.Find("GameManager"); //게임 중 파일을 지정할 수 없기 때문에, 게임 매니저라는 이름을 받아옴

        //HP설정 코드 추가 예정
        HP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //몹 이동 코드
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
