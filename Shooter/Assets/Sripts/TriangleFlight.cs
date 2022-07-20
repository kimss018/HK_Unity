using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleFlight : Flight
{
    public TriangleFlight()
    {
        type = FlightType.Triangle;
        name = "Enemy0";
        hp = 100;
        power = 10;
        speed = 2;
    }



    // Start is called before the first frame update
    void Start()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        
    }

    public override void SetPlayer(GameObject goPlayer)
    {
        goOriginPlayer = goPlayer;
    }

    public override void Move()
    {
        Rigidbody2D ownRd = gameObject.GetComponent<Rigidbody2D>();
        ownRd
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
