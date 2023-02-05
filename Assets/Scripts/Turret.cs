using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Enemy_temp;
    //public GameObject bullet = null;
    private GameObject closeEnemy = null;

    public Enemy_temp Enemy;

    CircleCollider2D scanCollider2D;

    private List<GameObject> collEnemys = new List<GameObject>();
    private float ftime;
    void Start()
    {
        scanCollider2D = GetComponent<CircleCollider2D>();
        //Enemy_temp = GetComponent<Enemy_temp>();
        //Enemy = GameObject.Find("Enemy_temp").GetComponent<Enemy_temp>();
    }

    
    void Update()
    {
        ftime = Time.deltaTime;
        if(gameObject.tag == "Tower")
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("접근");
        if (collision.tag == "Enemy") // 콜라이더에 Enemy 태그를 가진 오브젝트가 충돌했을 때
        {
            Debug.Log("발사");
            Enemy.OnDamaged(); // 충돌된 오브젝트에 데미지를 가한다
        }

    }
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

