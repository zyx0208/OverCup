using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float Respawn_time = 1f;
    public GameObject Enemy;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Respawn_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = Respawn_time;
            Instantiate(Enemy);
        }
    }
}
