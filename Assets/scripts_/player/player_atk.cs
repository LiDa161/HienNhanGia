using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class player_atk : MonoBehaviour
{
    player_move pl_movez;
    Vector3 mouse_position;
    float timer, timez;
    Vector2 rotation;
    Weapon current_weapon;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform fire_point;
    [SerializeField] bool can_fire = true;
    [SerializeField] float time_between, defaultTimeBetween;
    [SerializeField] List<Weapon> weapons;

    void Start()
    {
        current_weapon = weapons[0];
        SetWeaponActive(current_weapon, true);

        pl_movez = GetComponent<player_move>();
    }

    void Update()
    {       
        mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation = mouse_position - transform.position;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        if (!can_fire)
        {
            timer += Time.deltaTime;
            if (timer > time_between)
            {
                can_fire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && can_fire)
        {
            can_fire = false;
            fire();
        }

        check_weapons();
    }

    void fire()
    {
        var bullet_speed = Instantiate(bullet, fire_point.position, fire_point.rotation);
    }

    public void tang_toc_do_ban(int sp, float x)
    {
        defaultTimeBetween = time_between;
        time_between = sp;
        timez = x;
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(timez);
        time_between = defaultTimeBetween;
        print("het time");
    }

    void check_weapons()
    {
        if (current_weapon != null && current_weapon.weapon_opject.activeSelf)
        {
            var gun_sp = current_weapon.weapon_opject.GetComponent<SpriteRenderer>();

            if (gun_sp != null)
            {
                gun_sp.sprite = current_weapon.weapon_sprite;

                if (rotation.y > 0)
                {
                    if (rotation.x > 0) gun_sp.flipY = false;
                    if (rotation.x < 0) gun_sp.flipY = true;
                }
                else if (rotation.y < 0)
                {
                    if (rotation.x < 0) gun_sp.flipY = true;
                    if (rotation.x > 0) gun_sp.flipY = false;
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

    void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("hop_bi_an"))
        {
            random_weapon();
            collision.gameObject.SetActive(false);
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
        public int id;
        public GameObject weapon_opject;
        public Sprite weapon_sprite;
    }
}
