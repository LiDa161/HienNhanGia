using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static player_atk;

public class player_collision : MonoBehaviour
{
    player_atk player_Atk;
    health Health;
    player_move player_Move;
    Weapon current_weapon;
    [SerializeField] List<Weapon> weapons;
    [SerializeField] int min_health, max_health;

    void Start()
    {
        player_Atk = GetComponentInChildren<player_atk>();
        Health = GetComponent<health>();
        player_Move = GetComponent<player_move>();

        current_weapon = weapons[0];
        SetWeaponActive(current_weapon, true);
    }

    void Update()
    {
        check_weapons();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("up_rate_fire"))
        {
            print($"va cham voi : {collision.name}");
            if (player_Atk != null)
            {
                player_Atk.tang_toc_do_ban(0, 5f);
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("up_health"))
        {
            print($"va cham voi : {collision.name}");
            if (Health != null)
            {
                var healing = Random.Range(min_health, max_health);
                Health.tang_mau(healing);
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("up_speed"))
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
            random_weapon();
            collision.gameObject.SetActive(false);
        }
    }

    void check_weapons()
    {
        if (current_weapon != null && current_weapon.weapon_opject.activeSelf)
        {
            var gun_sp = current_weapon.weapon_opject.GetComponent<SpriteRenderer>();

            if (gun_sp != null)
            {
                gun_sp.sprite = current_weapon.weapon_sprite;

                if (player_Atk.rotation.y > 0)
                {
                    if (player_Atk.rotation.x > 0) gun_sp.flipY = false;
                    if (player_Atk.rotation.x < 0) gun_sp.flipY = true;
                }
                else if (player_Atk.rotation.y < 0)
                {
                    if (player_Atk.rotation.x < 0) gun_sp.flipY = true;
                    if (player_Atk.rotation.x > 0) gun_sp.flipY = false;
                }
            }
        }
    }

    void SetWeaponActive(Weapon new_weapon, bool is_active)
    {
        if (new_weapon != null)
        {
            new_weapon.weapon_opject.SetActive(is_active);
        }
    }

    void random_weapon()
    {
        var random_weapons = weapons[Random.Range(0, weapons.Count)];

        if (current_weapon == random_weapons)
        {
            print($"dang la vu khi : {current_weapon.weapon_opject.name}");
        }
        else if (current_weapon != null)
        {
            SetWeaponActive(current_weapon, false);
            print($"da an vu khi : {current_weapon.weapon_opject.name}");

            current_weapon = random_weapons;
            SetWeaponActive(current_weapon, true);
            print($"vu khi : {random_weapons.weapon_opject.name} active");
        }
        else
        {
            return;
        }
    }

    [System.Serializable]
    public class Weapon
    {
        public GameObject weapon_opject;
        public Sprite weapon_sprite;
    }
}
