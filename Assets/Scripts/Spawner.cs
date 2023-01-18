using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Respawn_time = 1f; //n초마다 몬스터 소환
    public GameObject Enemy;
    float timer;
    int monster_num; //라운드마다 소환되는 몬스터의 수
    int count;
    void Start()
    {
        monster_num = 20;
        count = 0;
        timer = Respawn_time;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
