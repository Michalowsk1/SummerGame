using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject shop;

    public Slider healthSlider;
    public Transform spawnPoint;
    public Transform PlayerPos;

    Vector2 mousePos;
    Vector2 playerPos;
    Vector2 direction;

    public static float hp;
    public static float armour;
    public static float dmg;
    public static float hpRecover;
    public static float bulletDamage;
    float damageTaken;

    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
        dmg = 1;
        hp = 10;
        bulletDamage = 1.0f;
        armour = 0.5f;
        hpRecover = 30;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = 1 + -hp / 10;
        if (ShopOpen.open == false)
        {
            Shooting();
            Healing();
        }
        else { }
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

    void Healing()
    {
        Timer = Timer + Time.deltaTime;

        if(Timer >= hpRecover)
        {
            hp += 0.1f;
            Timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "basicEnemy" || collision.gameObject.tag == "flyingEnemy")
        {
            damageTaken = -1 + armour;
            if(damageTaken > 0) damageTaken = 0;
            hp += damageTaken;
        }

        else if (collision.gameObject.tag == "projectile")
        {
            damageTaken = -2 + armour;
            if (damageTaken > 0) damageTaken = 0;
            hp += damageTaken;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "heal"))
        {
            if (Input.GetKey(KeyCode.Space) && PointSystem.pointCount >= 50 && hp != 10)
            {
                PointSystem.pointCount -= 50;
                hp = 10;
            }
        }
    }
}
