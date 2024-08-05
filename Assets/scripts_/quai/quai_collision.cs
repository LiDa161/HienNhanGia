using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quai_collision : MonoBehaviour
{
    health health_;
    [SerializeField] int min, max;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health_ = collision.gameObject.GetComponent<health>();
            var damage = Random.Range(min, max);
            health_.tru_mau(damage);

            if(health_.current_health <= 0)
            {
                collision.gameObject.SetActive(false);
                print("player die");
            }
        }
    }
}
