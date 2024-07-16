using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    player_atk player_Atk;
    
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
    }
}
