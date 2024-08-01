using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour
{
    player_atk player_Atk;
    health Health;
    player_move player_Move;
    [SerializeField] int min_health, max_health;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("up_rate_fire"))
        {
            print($"va cham voi : {collision}");
            player_Atk = collision.GetComponentInChildren<player_atk>();
            if (player_Atk != null)
            {
                player_Atk.TangTocdoban(0, 5f);
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("up_health"))
        {
            print($"va cham voi : {collision}");
            Health = collision.GetComponent<health>();
            if (Health != null)
            {
                var healing = Random.Range(min_health, max_health);
                Health.tang_mau(healing);
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("up_speed"))
        {
            print($"va cham voi : {collision}");
            player_Move = collision.GetComponent<player_move>();
            if (player_Move != null)
            {
                player_Move.tang_speed(16, 3);
            }
            Destroy(collision.gameObject);
        }
    }
}
