using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_atk : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform fire_point;
    [SerializeField] float fire_force = 10f;
    [SerializeField] float distance = 1f;
    player_move pl_movez;

    void Start()
    {
        pl_movez = GetComponent<player_move>();
    }

    void Update()
    {
        aim();
    }

    void OnFire()
    {
        fire();
    }

    void aim()
    {
        if (pl_movez.move_ != Vector2.zero)
        {
            fire_point.localPosition = pl_movez.move_ * distance;
        }
    }

    void fire()
    {
        Vector2 shoot = fire_point.localPosition;
        shoot.Normalize();
        var bullet_speed = Instantiate(bullet, fire_point.position, fire_point.rotation);
        bullet_speed.GetComponent<Rigidbody2D>().velocity = shoot * fire_force;
        bullet_speed.transform.Rotate(0, 0, Mathf.Atan2(shoot.y, shoot.x) * Mathf.Rad2Deg + 90f);
    }
}
