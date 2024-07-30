using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_player : MonoBehaviour
{
    [SerializeField] float fire_force = 10f;
    Rigidbody2D rb;
    health_quai health;
    int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * fire_force;        
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("quai"))
        {
            var name = collision.attachedRigidbody.name;
            Destroy(gameObject);
            health = collision.GetComponent<health_quai>();
            if (health != null)
            {
                health.tru_mau(20);
                if (health.current_health <= 0)
                {
                    game_manager.instance.set_text(count);
                    GameObject.Find(name).SetActive(false);
                    Debug.Log($"da diet quai");
                }
            }                        
        }
    }

}
