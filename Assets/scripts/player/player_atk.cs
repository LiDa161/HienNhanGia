using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_atk : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform fire_point;
    //[SerializeField] float fire_force = 10f;
    [SerializeField] float distance = 1f;
    player_move pl_movez;
    public Vector3 mouse_position;
    [SerializeField] bool can_fire = true;
    float timer;
    [SerializeField] float time_between;
    Camera camera;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        pl_movez = GetComponent<player_move>();
    }

    void Update()
    {
        mouse_position =camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mouse_position - transform.position;
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
        
        //aim();
    }

    /*void OnFire()
    {
        if (can_fire)
        {
            can_fire = false;
            fire();
        }       
    }*/

    /*void aim()
    {
        if (pl_movez.move_ != Vector2.zero)
        {
            fire_point.localPosition = pl_movez.move_ * distance;
        }
    }*/

    /*void fire()
    {
        Vector2 shoot = fire_point.localPosition;
        shoot.Normalize();
        var bullet_speed = Instantiate(bullet, fire_point.position, fire_point.rotation);
        bullet_speed.GetComponent<Rigidbody2D>().velocity = shoot * fire_force;
        bullet_speed.transform.Rotate(0, 0, Mathf.Atan2(shoot.y, shoot.x) * Mathf.Rad2Deg);
    }*/

    void fire()
    {
        var bullet_speed = Instantiate(bullet, fire_point.position, fire_point.rotation);
    }
}
