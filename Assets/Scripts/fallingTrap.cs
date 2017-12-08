using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingTrap : MonoBehaviour {

    public bool shouldChangeSprite = false;

    public Sprite spriteToChangeTo;

    private void Awake()
    {
        if (shouldChangeSprite && spriteToChangeTo == null)
        {
            Debug.Log("no sprite to change to on " + this.gameObject.name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().GameOver();
            if (shouldChangeSprite)
            {
                if (spriteToChangeTo != null)
                {
                    GetComponent<SpriteRenderer>().sprite = spriteToChangeTo;
                }
            }
        }else
        {
            Destroy(this.gameObject,0.04f);
        }
    }
}
