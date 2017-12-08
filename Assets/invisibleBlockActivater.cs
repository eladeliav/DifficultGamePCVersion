using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleBlockActivater : MonoBehaviour {

    public bool shouldDisable = true;

    public GameObject toDisable;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = true;
            if (shouldDisable && toDisable != null)
            {
                toDisable.SetActive(false);
            }
        }
    }

}
