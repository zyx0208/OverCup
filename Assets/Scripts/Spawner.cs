using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Respawn_time = 1f; //n초마다 몬스터 소환
    public GameObject Enemy;
    float timer;
    int monster_num; //라운드마다 소환되는 몬스터의 수
    public int dead_moster_num; //라운드 클리어를 확인하기 위한 몬스터가 죽은 숫자
    int count; //몬스터를 몇마리 소환했는지 체크하기 위한 변수
    
    //스테이지 클리어 후 Invoke()를 통한 시간 지연을 위해 따로 함수 설정
    void stage_setting() //일반전 설정
    {
        count = 0;
    }
    void boss_stage_setting() //보스전 설정
    {
        count = monster_num - 1;
    }

    void Start()
    {
        monster_num = 20; //여기서 몬스터의 수(n) 조절
        dead_moster_num = monster_num;
        count = 0;
        timer = Respawn_time;
    }

    // Update is called once per frame
    void Update()
    {
        //몬스터를 n마리만큼 소환시키는 코드
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
        //만약 n마리의 몬스터가 죽으면 스테이지 클리어
        if(dead_moster_num == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Stage_Clear();
            if(GameObject.Find("GameManager").GetComponent<GameManager>().stage % 10 == 0) //보스의 경우
            {
                dead_moster_num = 1; 
                Invoke("boss_stage_setting", 5f); //스테이지 클리어 후 대기 시간 설정
            }
            else //일반 몬스터의 경우
            {
                dead_moster_num = monster_num;
                Invoke("stage_setting", 5f); //스테이지 클리어 후 대기 시간 설정
            }
            
        }
    }
}
