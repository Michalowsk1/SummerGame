using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject[] PlayerLooks;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D rb;

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        for (int i = 0;  i < PlayerLooks.Length; i++)
        {
            PlayerLooks[i].SetActive(false);
        }
        PlayerLooks[0].SetActive(true);

        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopOpen.open == false)
        {
            Controls();
            Turning();
        }
        else { }
    }

    void Controls()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position = (new Vector2(player.transform.position.x, player.transform.position.y + speed));
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position = (new Vector2(player.transform.position.x, player.transform.position.y - speed));
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position = (new Vector2(player.transform.position.x - speed, player.transform.position.y));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position = (new Vector2(player.transform.position.x + speed, player.transform.position.y));
        }

        else rb.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.10f;
        }
        else speed = 0.05f;
    }

    void Turning()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            for (int i = 0; i < PlayerLooks.Length; i++)
            {
                PlayerLooks[i].SetActive(false);
            }
            PlayerLooks[1].SetActive(true);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            for (int i = 0; i < PlayerLooks.Length; i++)
            {
                PlayerLooks[i].SetActive(false);
            }
            PlayerLooks[0].SetActive(true);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            for (int i = 0; i < PlayerLooks.Length; i++)
            {
                PlayerLooks[i].SetActive(false);
            }
            PlayerLooks[2].SetActive(true);
            player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            for (int i = 0; i < PlayerLooks.Length; i++)
            {
                PlayerLooks[i].SetActive(false);
            }
            PlayerLooks[2].SetActive(true);
            player.transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
    }


}
