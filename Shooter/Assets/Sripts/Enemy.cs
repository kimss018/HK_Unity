using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    Rigidbody2D rd;

    public float curBulletDelay = 0f;
    public float maxBulletDelay;

    public GameObject goBullet;
    public GameObject goPlayer;

    public int nDmgPoint;

    public ObjectManager objManager;

    public string name;
    


   



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // rd = GetComponent<Rigidbody2D>();
        // rd.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        ReloadBullet();
    }

    void Fire()
    {
        if(curBulletDelay < maxBulletDelay)
        {
            return;
        }
         
        // GameObject createBullet = Instantiate(goBullet, transform.position, Quaternion.identity);
        GameObject createBullet = objManager.MakeObject("EnemyBullet");
        createBullet.transform.position = transform.position;

        Rigidbody2D rd = createBullet.GetComponent<Rigidbody2D>();
        
        Vector3 dirVec = goPlayer.transform.position - transform.position;

        rd.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);

        curBulletDelay = 0;
    }

    void ReloadBullet()
    {
        curBulletDelay += Time.deltaTime;
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Border")
        {
            gameObject.SetActive(false);
            
            // Destroy(gameObject);

            
        }
        else if(collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.power);
            
            collision.gameObject.SetActive(false);
            // Destroy(collision.gameObject);
        }
    }

    void OnHit(float playerBulletPower)
    {
        health -= playerBulletPower;

        spriteRenderer.sprite = sprites[1];

        Invoke("ReturnSprite", 0.1f);  // startcouroutine ½áº¸±â.

        if(health <= 0)
        {
            gameObject.SetActive(false);
            // Destroy(gameObject);

            
            

            Player playerLogic = goPlayer.GetComponent<Player>();
            playerLogic.nScore += nDmgPoint;
        }
    }

    private void OnEanble()
    {
        health = 10;
    }
}
