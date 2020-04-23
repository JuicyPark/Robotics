using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Status : MonoBehaviour
{
    public bool isActivate;

    public Action TakedDamage;
    public Action LackedMana;

    //float maxHealthPoint;
    float healthPoint = 100f;
    float manaPoint = 5f;
    float exp;
    public float HealthPoint { get => healthPoint; }
    public float ManaPoint { get => manaPoint; }
    public float Exp { get => exp; }

    public void TakeDamage(float damage)
    {
        // GUI 변화 연결시키고, 반짝이 효과 연결
        TakedDamage?.Invoke();
        healthPoint -= damage;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("패배");
    }

    void FixedUpdate()
    {
        if (isActivate)
        {
            exp += Time.deltaTime;
            manaPoint += Time.deltaTime;
        }
        else
        {
            if (manaPoint > 0)
            {
                manaPoint -= Time.deltaTime;
            }
            else
            {
                LackedMana?.Invoke();
            }
        }
    }
}
