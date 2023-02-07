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
        transform.Translate(targetPosition * Time.deltaTime * 30.0f); // Turret�Լ����� ���� �Ѿ��� �������� �Ѿ��� �̵���Ŵ
        
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 4.0f) // �Ѿ��� Ÿ���� �����Ÿ�(4.0f)�� ����� �ı���
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
}
