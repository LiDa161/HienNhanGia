using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_quai : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    health health;
    damage_text dmg;
    [SerializeField] float fire_force = 5f;
    [SerializeField] int min_damage, max_damage;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        move_player();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var name = collision.attachedRigidbody.name;
            Destroy(gameObject);
            health = collision.GetComponent<health>();
            dmg = collision.GetComponent<damage_text>();
            if (health != null)
            {
                var damage = Random.Range(min_damage, max_damage);
                health.tru_mau(damage);
                dmg.set_text(damage);
                if (health.current_health <= 0)
                {
                    GameObject.Find(name).SetActive(false);
                    Debug.Log($"da diet player");
                }
            }
        }
    }  

    void move_player()
    {
        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * fire_force;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        Destroy(gameObject, 2f);
    }
}
