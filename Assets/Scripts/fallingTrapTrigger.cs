using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingTrapTrigger : MonoBehaviour {

    private Transform theFallingTrap;

    public float fallSpeed = 10f;

    public GameObject[] borders;

    private void Awake()
    {
        theFallingTrap = transform.GetChild(0);
    }

    private void Update()
    {
        if(borders.Length == 0)
        {
            /*for(int i = 0;i < borders.Length; i++)
            {
                borders[i] = GameObject.FindGameObjectWithTag("Borders");
            }*/
            borders = GameObject.FindGameObjectsWithTag("Borders");

        }

        if(theFallingTrap != null && borders != null)
        {
            for(int i = 0; i < borders.Length; i++)
            {
                Physics2D.IgnoreCollision(theFallingTrap.GetComponent<PolygonCollider2D>(), borders[i].GetComponent<BoxCollider2D>());
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            theFallingTrap.GetComponent<SpriteRenderer>().enabled = true;
            theFallingTrap.GetComponent<PolygonCollider2D>().enabled = true;
            theFallingTrap.gameObject.GetComponent<Rigidbody2D>().gravityScale = fallSpeed;
            return;
        }
        

    }

}
