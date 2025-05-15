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
        if(collision.gameObject.tag == "bar")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "basicEnemy")
        {
            //basicEnemy.hp--;
            Destroy(gameObject);
        }
    }
}
