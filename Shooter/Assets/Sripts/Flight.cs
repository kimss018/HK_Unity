using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlightType
{
    Triangle,
    Circle
}

public abstract class Flight : MonoBehaviour
{
    protected FlightType type;
    protected string name;
    protected float hp;
    protected float power;
    protected float speed;

    public abstract void Attack();


    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }
}


/*
public class Flight : MonoBehaviour, Fligh
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/

