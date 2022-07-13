using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private Vector3 direction;
    
    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        // Destroy(gameObject, 5.0f);

        Invoke("ReturnBulletToPooling", 5.0f);

    }

    public void ReturnBulletToPooling()
    {
        ObjectPool.ReturnObject(this);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction);
    }
}
