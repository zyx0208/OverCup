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
            Debug.Log("�� ����");
            GameObject target = checkEnemys[0];
            if (this.gameObject.CompareTag("Tower"))
            {
                Debug.Log("Ÿ�� Ȯ��");
                if (target != null && sTime > 1.0f)
                {
                    Debug.Log("�߻� �غ�");
                    sTime = 0.0f;
                    var Bullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
                    Bullet.GetComponent<Bullet>().targetPosition = (target.transform.position - transform.position).normalized;
                }
            }
            else
            {
                Debug.Log("Ÿ�� Ȯ�� �Ұ�");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Ž��");
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
    public Vector2 enemyPos; // Ž���� ���� ��ġ
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
            Bul.transform.position = new Vector2(posB.x, posB.y); // ��ž ��ġ�� �Ѿ� ����
            //Bul.transform.position = Vector3.MoveTowards(Bul.transform.position, enemyPos, Speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("����");
        if (collision.tag == "Enemy") // �ݶ��̴��� Enemy �±׸� ���� ������Ʈ�� �浹���� ��
        {
            Bullet.enemyPos = collision.gameObject.transform.position;
            Debug.Log(enemyPos);
            Debug.Log("�߻�");
            Shot();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") // �ݶ��̴��� Enemy �±׸� ���� ������Ʈ�� �浹���� ��
        {
            enemyPos = collision.gameObject.transform.position;
            Debug.Log(enemyPos);
            //Debug.Log("�߻�");
            //Shot();
        }
    }
    */
}

class Tier
{
    int turretTier = 0; // �� Ƽ� ������
    int Damage; // Ƽ�� * ���� ������
    public int tierDamage(int tier, int Damage)
    {
        if(tier == 0)       // �븻
        {
            return Damage = Damage * Normal();
        }
        else if (tier == 1) // ����
        {
            return Damage = Damage * Rare();
        }
        else if (tier == 2) // ����
        {
            return Damage = Damage * Epic();
        }
        else if(tier == 3) // ��������
        {
            return Damage = Damage * Legendary();
        }
        else               // ����
        {
            return Damage = -1;
        }
    }
    public int Normal() // �븻
    {
        return turretTier = 10;
    }
    public int Rare() // ����
    {
        return turretTier = 10;
    }
    public int Epic() // ����
    {
        return turretTier = 150;
    }
    public int Legendary() // ��������
    {
        return turretTier = 300;
    }
}

class Elemental : Tier
{
    int totalDamage = 0; // ��ü ������
    int elementalDamage = 0; // �� ���Һ� ������
    public int elementalAttack(int elemental, int tier)
    {
        if(elemental == 0)       // ��
        { 
            return Fire(tier); 
        }
        else if(elemental == 1)  // ����
        {
            return Thunder(tier);
        }
        else if(elemental == 2)  // ��
        {
            return Poison(tier);
        }
        else if(elemental == 3)  //��
        {
            return Water(tier);
        }
        else if(elemental == 4)  //�ٶ�
        {
            return Wind(tier);
        }
        else if(elemental == 5)  //����
        {
            return Ice(tier);
        }
        else                     // ����
        {
            return totalDamage = -2;
        }
        
    }
    public int Fire(int tier) // ��
    {
        elementalDamage = 10;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Thunder(int tier) // ����
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Poison(int tier) // ��
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Water(int tier) // ��
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Wind(int tier) // �ٶ�
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
    public int Ice(int tier) // ����
    {
        elementalDamage = 5;
        totalDamage = tierDamage(tier, elementalDamage);
        return totalDamage;
    }
}

