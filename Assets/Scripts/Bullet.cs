using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public GameObject ExplosionParticle = null;
    public GameObject Enemy_temp;
    // Use this for initialization

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * 30.0f);

        // ���� �θ��� ���̰� �����Ÿ�(1.5f) �����ϸ� ����
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 4.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") // �ݶ��̴��� Enemy �±׸� ���� ������Ʈ�� �浹���� ��
        {
            Debug.Log("����!");
            Destroy(gameObject);
            Enemy_temp = GameObject.Find("Enemy_temp(Clone)");
            Enemy_temp.GetComponent<Enemy_temp>().OnDamaged(); // �浹�� ������Ʈ�� �������� ���Ѵ�
        }
    }

    /*
    Rigidbody2D rigid;
    CapsuleCollider2D coll;
    public GameObject Enemy_temp;
    public float Speed = 1.0f;
    private float Enemy_Pos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        Enemy_temp = GameObject.Find("Enemy_temp");
    }


    void Update()
    {

    }

    void Move()
    {
        Enemy_Pos = 
        this.transform.position = Vector3.MoveTowards(this.transform.position, Enemy_Pos, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") // �ݶ��̴��� Enemy �±׸� ���� ������Ʈ�� �浹���� ��
        {
            Debug.Log("����!");
            Enemy_temp.GetComponent<Enemy_temp>().OnDamaged(); // �浹�� ������Ʈ�� �������� ���Ѵ�
            Destroy(gameObject);
        }
    }
    */
}
