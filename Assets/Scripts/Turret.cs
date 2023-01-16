using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
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

