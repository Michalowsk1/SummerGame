using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bar" || collision.gameObject.tag == "cave")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "basicEnemy" || collision.gameObject.tag == "flyingEnemy")
        {
            Destroy(gameObject);
        }
    }
}
