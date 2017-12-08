using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisbleTrap : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            collision.gameObject.GetComponent<Player>().GameOver();
        }
    }
}
