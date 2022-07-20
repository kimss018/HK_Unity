using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite dmgSprite;
    public int hitTime = 3;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    public void DamageWall(int loss)
    {
        spriteRenderer.sprite = dmgSprite;

        hitTime -= loss;

        if (hitTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
