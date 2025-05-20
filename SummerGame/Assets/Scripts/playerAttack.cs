using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public Slider healthSlider;
    public Transform spawnPoint;
    public Transform PlayerPos;

    Vector2 mousePos;
    Vector2 playerPos;
    Vector2 direction;

    public static float hp;
    public static float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        bulletDamage = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = 1 + -hp / 10;
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerPos = PlayerPos.position;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            direction = (mousePos - playerPos).normalized;

            GameObject bullet = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
            bulletrb.velocity = (new Vector3(direction.x, direction.y, 0) * 15);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "basicEnemy")
        {
            hp--;
        }
    }
}
