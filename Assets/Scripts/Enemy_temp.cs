using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_temp : MonoBehaviour
{
    public int speed; //몬스터의 이동속도
    public int HP; //몬스터의 체력
    public GameObject GM; //플레이어의 HP를 관리하기 위해 사용
    public GameObject spawner; //몬스터의 죽은 횟수를 관리하기 위해 사용
    Vector2 direction;

    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(-5.4f, 1.8f, 0f); //몹 생성 지점 설정
        direction = new Vector2(1f, 0f);
        GM = GameObject.Find("GameManager"); //게임 중 파일을 지정할 수 없기 때문에, 게임 매니저라는 이름을 받아옴
        spawner = GameObject.Find("Spawner"); //몬스터의 죽음을 확인하기 위한 스포너 코드 불러오기
        
        //HP설정 코드
        if(GM.GetComponent<GameManager>().stage % 10 == 0) //보스의 경우
        {
            HP = 10 * GM.GetComponent<GameManager>().stage * 10;
        }
        else //일반 몬스터의 경우
        {
            HP = 10 * GM.GetComponent<GameManager>().stage; 
        }
        Debug.Log("방금 생성된 적의 체력 : " + HP); //이거 지워도 됨
    }

    void Update()
    {
        //몹 이동 코드
        this.transform.Translate(direction * speed * Time.deltaTime);
        if(HP <= 0)
        {
            spawner.GetComponent<Spawner>().dead_moster_num--;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //몬스터가 투명벽에 닿으면, 등록된 값에 따라 방향 전환
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

        //맵 끝까지 도달하면, 플레이어는 데미지를 입고 해당 몬스터 삭제
        if (collision.tag == "End")
        {
            GM.GetComponent<GameManager>().Damage(1);
            GM.GetComponent<GameManager>().Log_HP();
            spawner.GetComponent<Spawner>().dead_moster_num--;
            Destroy(this.gameObject);
        }
    }
}
