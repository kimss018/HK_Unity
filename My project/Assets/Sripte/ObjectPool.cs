using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;

        Initialize(10);
    }

    private void Initialize(int initCount)
    {
        for(int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private Bullet CreateNewObject()
    {
        Bullet newObject = Instantiate(poolingObjectPrefab).GetComponent<Bullet>();
        newObject.gameObject.SetActive(false);
        newObject.transform.SetParent(transform);

        return newObject;
    }

    public static Bullet GetObject()
    {
        if(Instance.poolingObjectQueue.Count > 0)
        {
            Bullet obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);

            return obj;
        }

        else
        {
            Bullet newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);

            return newObj;
        }
        
    }

    public static void ReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
