using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static player_atk;

public class player_collision : MonoBehaviour
{
    health Health;
    player_move player_Move;
    player_atk player_Atk;
    player_change_weapons player_Change;
    [SerializeField] int min_health, max_health;

    void Start()
    {
        player_Atk = GetComponentInChildren<player_atk>();
        player_Change = GetComponentInChildren<player_change_weapons>();
        Health = GetComponent<health>();
        player_Move = GetComponent<player_move>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("up_rate_fire"))
        {
            print($"va cham voi : {collision.name}");
            if (player_Change != null)
            {
                player_Change.tang_toc_do_ban(0, 5f);
            }
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("up_health"))
        {
            print($"va cham voi : {collision.name}");
            if (Health != null)
            {
                var healing = Random.Range(min_health, max_health);
                Health.tang_mau(healing);
            }
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("up_speed"))
        {
            print($"va cham voi : {collision.name}");
            if (player_Move != null)
            {
                player_Move.tang_speed(16, 3);
            }
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("hop_bi_an"))
        {
            print($"va cham voi : {collision.name}");
            player_Atk.random_weapon();
            collision.gameObject.SetActive(false);
        }
    }    
}
