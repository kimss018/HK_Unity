using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_0 : MonoBehaviour, IWeapon
{
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

    public void Shoot(GameObject obj, GameObject player)
    {
        GameObject goBullet_0 = Instantiate(obj);
        goBullet_0.transform.position = player.transform.position;

        Rigidbody2D rigid = goBullet_0.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}
