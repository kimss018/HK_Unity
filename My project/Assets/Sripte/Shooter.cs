using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // [SerializeField]
    // private GameObject bulletPrefab;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hitResult;
            
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitResult))
            {
                Bullet bullet = ObjectPool.GetObject();
                Vector3 direction = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
                bullet.transform.position = direction.normalized ;
                // normalized vs magnitude  << 
                bullet.Shoot(direction.normalized);
            }
        }
    }
}
