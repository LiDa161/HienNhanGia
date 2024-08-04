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
    public Vector2 rotation;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform fire_point;
    [SerializeField] bool can_fire = true;
    [SerializeField] float time_between, defaultTimeBetween;

    void Start()
    {
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
}
