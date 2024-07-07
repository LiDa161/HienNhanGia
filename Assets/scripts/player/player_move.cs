using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;



public class player_move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    float speed;
    [SerializeField] float speed_basic = 8f;
    SpriteRenderer sp;
    public Vector2 move_;
    Vector2 mouse_position;
    int current;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        player_ani();
        speed = Math.Clamp(move_.magnitude, 0.0f, 1.0f);       
    }

    void FixedUpdate()
    {
        rb.velocity = move_ * speed * speed_basic;
    }

    void OnMove(InputValue input)
    {
        move_ = input.Get<Vector2>();
        Debug.Log(move_.magnitude);
    }

    void player_ani()
    {
        if (move_ != Vector2.zero)
        {
            ani.SetFloat("velocity.x", move_.x);
            ani.SetFloat("velocity.y", move_.y);
        }
        ani.SetFloat("speed", speed);
        /*if (rb.velocity.sqrMagnitude > 0)
        {
            if(move_.x > 0 && move_.y == 0)
            {
                ani.Play("run_e");
                current = 1;
            }
            else if (move_.x > 0 && move_.y > 0)
            {
                ani.Play("run_ne");
                current = 2;
            }
            else if (move_.x > 0 && move_.y < 0)
            {
                ani.Play("run_se");
                current = 3;
            }
            else if (move_.x < 0 && move_.y == 0)
            {
                ani.Play("run_w");
                current = 4;
            }
            else if (move_.x < 0 && move_.y > 0)
            {
                ani.Play("run_nw");
                current = 5;
            }
            else if (move_.x < 0 && move_.y < 0)
            {
                ani.Play("run_sw");
                current = 6;
            }
            else if (move_.x == 0 && move_.y > 0)
            {
                ani.Play("run_n");
                current = 7;
            }
            else if (move_.x == 0 && move_.y < 0)
            {
                ani.Play("run_s");
                current = 8;
            }
        }
        else
        {
            switch (current)
            {
                case 1:
                    ani.Play("idle_e");
                    break;
                case 2:
                    ani.Play("idle_ne");
                    break;
                case 3:
                    ani.Play("idle_se");
                    break;

                case 4:
                    ani.Play("idle_w");
                    break;
                case 5:
                    ani.Play("idle_nw");
                    break;
                case 6:
                    ani.Play("idle_sw");
                    break;

                case 7:
                    ani.Play("idle_n");
                    break;
                case 8:
                    ani.Play("idle_s");
                    break;
            }
        }*/

    }
}

