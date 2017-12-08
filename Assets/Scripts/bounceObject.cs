using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceObject : MonoBehaviour {

    public float bounceForce = 10f;

    public bool shouldDisable = true;

    public GameObject toDisable;

    private void Awake()
    {
        if (shouldDisable && toDisable == null){
            Debug.Log("don't have object to disable");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce);
            if(shouldDisable){
                if(toDisable != null){
                    toDisable.SetActive(false);
                }
            }
        }
    }
}
