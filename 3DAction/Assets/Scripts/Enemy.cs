﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;

    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();

            curHealth -= bullet.damage;

            StartCoroutine(OnDamage());

            Destroy(other.gameObject);

        }

        if(other.tag == "OffenseShort")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            
            curHealth -= weapon.power;

            StartCoroutine(OnDamage());
           
        }
    }

    IEnumerator OnDamage()
    {
        mat.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        if(curHealth > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = Color.grey;

            Destroy(gameObject, 0.3f);
        }
    }
}
