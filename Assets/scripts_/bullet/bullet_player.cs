using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_player : MonoBehaviour
{
    Rigidbody2D rb;
    health_quai health;
    [SerializeField] float fire_force = 10f;
    [SerializeField] int min_damage, max_damage/*, count*/;
    [SerializeField] int count;

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
                var damage = Random.Range(min_damage, max_damage);
                health.tru_mau(damage);
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
