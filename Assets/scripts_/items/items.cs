using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    //player_atk player_Atk;
    player_change_weapons player_Change;
    health Health;
    player_move player_Move;
    [SerializeField] int min_health, max_health;
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print($"va cham voi : {collision}");
            player_Change = collision.GetComponentInChildren<player_change_weapons>();
            if (player_Change != null)
            {
                player_Change.tang_toc_do_ban(0, 5f);
            }
            Destroy(gameObject);

            Health = collision.GetComponent<health>();
            if (Health != null)
            {
                var healing = Random.Range(min_health, max_health);
                Health.tang_mau(healing);
            }

            player_Move = collision.GetComponent<player_move>();
            if (player_Move != null)
            {
                player_Move.tang_speed(16, 3);
            }
            Destroy(gameObject);
        }

        /*if (collision.gameObject.CompareTag("Player"))
        {
            print($"va cham voi : {collision}");
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
            print($"va cham voi : {collision}");
            player_Move = collision.GetComponent<player_move>();
            if (player_Move != null)
            {
                player_Move.tang_speed(16, 3);
            }
            Destroy(gameObject);
        }*/
    }
}
