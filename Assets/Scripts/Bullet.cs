using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public GameObject Enemy_temp;

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * 30.0f); // Turret함수에서 받은 총알의 목적지로 총알을 이동시킴
        
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 4.0f) // 총알이 타워의 사정거리(4.0f)를 벗어나면 파괴됨
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") // 콜라이더에 Enemy 태그를 가진 오브젝트가 충돌했을 때
        {
            Debug.Log("공격!");
            Destroy(gameObject);
            Enemy_temp = GameObject.Find("Enemy_temp(Clone)");
            Enemy_temp.GetComponent<Enemy_temp>().OnDamaged(); // 충돌된 오브젝트에 데미지를 가한다
        }
    }
}
