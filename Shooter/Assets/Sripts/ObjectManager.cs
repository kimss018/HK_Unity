using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject[] goEnemy1;
    public GameObject enemyPrefab;

    GameObject[] goEnemy2;
    public GameObject enemyPrefab2;

    GameObject[] goBulletPlayer;
    public GameObject bulletPlayer;
    
    GameObject[] goBulletEnemy;
    public GameObject bulletEnemy;

    GameObject[] goTargetPool;



    // Start is called before the first frame update
    void Start()
    {
        return;
        goEnemy1 = new GameObject[10];
        goEnemy2 = new GameObject[2];


        goBulletEnemy = new GameObject[100];

        goBulletPlayer = new GameObject[100];

        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        for (int i = 0; i < goEnemy1.Length; i++)
        {
            goEnemy1[i] = Instantiate(enemyPrefab);
            goEnemy1[i].SetActive(false);
        }

        for (int i = 0; i < goEnemy2.Length; i++)
        {
            goEnemy2[i] = Instantiate(enemyPrefab2);
            goEnemy2[i].SetActive(false);
        }

        for (int i = 0; i < goBulletEnemy.Length; i++)
        {
            goBulletEnemy[i] = Instantiate(bulletEnemy);
            goBulletEnemy[i].SetActive(false);
        }
        for (int i = 0; i < goBulletPlayer.Length; i++)
        {
            goBulletPlayer[i] = Instantiate(bulletPlayer);
            goBulletPlayer[i].SetActive(false);
        }
    }

    public GameObject MakeObject(string objType)
    {
        switch(objType)
        {
            case "A":
                {
                    goTargetPool = goEnemy1;
                }
                break;

            case "B":
                {
                    goTargetPool = goEnemy2;
                }
                break;
            
            case "EnemyBullet":
                {
                    goTargetPool = goBulletEnemy;
                }
                break;

            case "PlayerBullet":
                {
                    goTargetPool = goBulletPlayer;
                }
                break;
        }

        for(int i = 0; i < goTargetPool.Length; i++)
        {
            if (goTargetPool[i].activeSelf == false)
            {
                goTargetPool[i].SetActive(true);
                return goTargetPool[i];
            }
        }

        return null;
    }
}
