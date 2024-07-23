using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_quai : MonoBehaviour
{
    GameObject player;
    [SerializeField] float fire_force = 5f;
    Rigidbody2D rb;
    health health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<health>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * fire_force;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        Destroy(gameObject, 2);
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
            if (health != null)
            {
                health.tru_mau(20);
                if (health.current_health <= 0)
                {
                    GameObject.Find(name).SetActive(false);
                    Debug.Log($"da diet player");
                }
            }
        }
    }
}
