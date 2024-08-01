using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    player_atk player_Atk;
    health Health;
    player_move player_Move;
    [SerializeField] int min_health, max_health;
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fire_point"))
        {
            player_Atk = collision.GetComponent<player_atk>();
            if (player_Atk != null)
            {
                player_Atk.TangTocdoban(0, 5f);
            }
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Health = collision.GetComponent<health>();
            if (Health != null)
            {
                var healing = Random.Range(min_health, max_health);
                Health.tang_mau(healing);
            }
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            player_Move = collision.GetComponent<player_move>();
            if (player_Move != null)
            {
                //player_Move.TangTocdoban(0, 5f);
            }
            Destroy(gameObject);
        }
    }
}
