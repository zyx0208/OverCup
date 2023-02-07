using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet = null;
    private GameObject closeEnemy = null;

    private List<GameObject> checkEnemys = new List<GameObject>();
    private float sTime = 0;

    void Start()
    {

    }

    void Update()
    {
        sTime += Time.deltaTime;
        if (checkEnemys.Count > 0)
        {
            Debug.Log("적 조준");
            GameObject target = checkEnemys[0];
            if (this.gameObject.CompareTag("Tower"))
            {
                Debug.Log("타워 확인");
                if (target != null && sTime > 1.0f)
                {
                    Debug.Log("발사 준비");
                    sTime = 0.0f;
                    var Bullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
                    Bullet.GetComponent<Bullet>().targetPosition = (target.transform.position - transform.position).normalized;
                }
            }
            else
            {
                Debug.Log("타워 확인 불가");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("탐지");
            checkEnemys.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject go in checkEnemys)
        {
            if (go == collision.gameObject)
            {
                checkEnemys.Remove(go);
                break;
            }
        }
    }
    /*
    public GameObject Enemy_temp;
    public GameObject Bullet;

    CircleCollider2D scanCollider2D;

    private List<GameObject> collEnemys = new List<GameObject>();
    private float ftime;
    public Vector2 enemyPos; // 탐지된 적의 위치
    public float Speed = 1.0f;


    void Start()
    {
        scanCollider2D = GetComponent<CircleCollider2D>();
        Enemy_temp = GameObject.Find("Enemy_temp");
    }

    
    void Update()
    {
        ftime = Time.deltaTime;
        if(gameObject.tag == "Tower")
        {
            
        }
    }

    void Shot()
    {
        Debug.Log("Shot!!");
        ftime += Time.deltaTime;
        if(ftime > 0.5f)
        {
            Debug.Log("Shot!!!!");
            GameObject Bul = Instantiate(Bullet);
            Vector2 posB = this.gameObject.transform.position;
            Bul.transform.position = new Vector2(posB.x, posB.y); // 포탑 위치에 총알 생성
            //Bul.transform.position = Vector3.MoveTowards(Bul.transform.position, enemyPos, Speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("접근");
        if (collision.tag == "Enemy") // 콜라이더에 Enemy 태그를 가진 오브젝트가 충돌했을 때
        {
            Bullet.enemyPos = collision.gameObject.transform.position;
            Debug.Log(enemyPos);
            Debug.Log("발사");
            Shot();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") // 콜라이더에 Enemy 태그를 가진 오브젝트가 충돌했을 때
        {
            enemyPos = collision.gameObject.transform.position;
            Debug.Log(enemyPos);
            //Debug.Log("발사");
            //Shot();
        }
    }
    */
}

class Tier
{
    int turretTier = 0; // 각 티어별 데미지
    int Damage; // 티어 * 원소 데미지
    public int tierDamage(int tier, int Damage)
    {
        if(tier == 0)       // 노말
        {
            return Damage = Damage * Normal();
        }
        else if (tier == 1) // 레어
        {
            return Damage = Damage * Rare();
        }
        else if (tier == 2) // 에픽
        {
            return Damage = Damage * Epic();
        }
        else if(tier == 3) // 레전더리
        {
            return Damage = Damage * Legendary();
        }
        else               // 오류
        {
            return Damage = -1;
        }
    }
    public int Normal() // 노말
    {
        return turretTier = 10;
    }
    public int Rare() // 레어
    {
        return turretTier = 10;
    }
    public int Epic() // 에픽
    {
        return turretTier = 150;
    }
    public int Legendary() // 레전더리
    {
        return turretTier = 300;
    }
}

class Elemental : Tier
{
    int totalDamage = 0; // 전체 데미지
    int elementalDamage = 0; // 각 원소별 데미지
    public int elementalAttack(int elemental, int tier)
    {
        if(elemental == 0)       // 불
        { 
            return Fire(tier); 
        }
        else if(elemental == 1)  // 번개
        {
            return Thunder(tier);
        }
        else if(elemental == 2)  // 독
        {
            return Poison(tier);
        }
        else if(elemental == 3)  //물
        {
            return Water(tier);
        }
        else if(elemental == 4)  //바람
        {
            return Wind(tier);
        }
        else if(elemental == 5)  //얼음
        {
            return Ice(tier);
        }
        else                     // 오류
        {
            return totalDamage = -2;
        }
        
    }
    public int Fire(int tier) // 불
    {
        elementalDamage = 10;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Thunder(int tier) // 번개
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Poison(int tier) // 독
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Water(int tier) // 물
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Wind(int tier) // 바람
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Ice(int tier) // 얼음
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
}

