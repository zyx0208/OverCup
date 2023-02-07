using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet = null;
    private GameObject closeEnemy = null;

    private List<GameObject> checkEnemys = new List<GameObject>(); // 적이 남아있는지 체크해주는 리스트
    private float sTime = 0;

    void Start()
    {

    }

    void Update()
    {
        sTime += Time.deltaTime;
        if (checkEnemys.Count > 0)
        {
            GameObject target = checkEnemys[0]; // 가장 첫번째 적 타겟팅
            if (this.gameObject.CompareTag("Tower")) // 타워의 태그를 확인해 타워들을 구분
            {
                if (target != null && sTime > 1.0f)
                {
                    sTime = 0.0f;
                    var Bullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
                    Bullet.GetComponent<Bullet>().targetPosition = (target.transform.position - transform.position).normalized; // 총알의 목적지를 Bullet 함수로 넘겨줌
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
            checkEnemys.Add(collision.gameObject); // 적이 탐지되면 체크리스트에 적의 정보를 저장
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject go in checkEnemys)
        {
            if (go == collision.gameObject)
            {
                checkEnemys.Remove(go); // 탐지범위를 벗어나면 체크리스트에서 제거
                break;
            }
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

