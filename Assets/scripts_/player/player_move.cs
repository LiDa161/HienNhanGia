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
    int current;
    [SerializeField] float dash_boost;
    [SerializeField] float dash_time;
    float dash_time_;
    [SerializeField] bool is_dashing;
    [SerializeField] GameObject ghost_dash;
    [SerializeField] float ghost_delay;
    Coroutine coroutine_ghost;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        /*Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        player_ani();
        speed = Math.Clamp(move_.magnitude, 0.0f, 1.0f);  
        if (Input.GetKeyDown(KeyCode.Space) && dash_time_ <= 0 && is_dashing == false)
        {
            speed_basic += dash_boost;
            dash_time_ = dash_time;
            is_dashing = true;
            start_ghost();
        }
        
        if (dash_time_ <= 0 && is_dashing == true)
        {
            speed_basic -= dash_boost;
            is_dashing = false;
            stop_ghost();
        }
        else
        {
            dash_time_ -= Time.deltaTime;
        }
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
    }

    void stop_ghost()
    {
        if (coroutine_ghost != null)
        {
            StopCoroutine(coroutine_ghost);
        }
    }

    void start_ghost()
    {
        if (coroutine_ghost != null)
        {
            StopCoroutine(coroutine_ghost);
        }
        coroutine_ghost = StartCoroutine(ghost_dash_());
    }

    IEnumerator ghost_dash_()
    {
        while (true)
        {
            var ghost = Instantiate(ghost_dash, transform.position, transform.rotation);
            Sprite current_sp = sp.sprite;
            ghost.GetComponent<SpriteRenderer>().sprite = current_sp;

            Destroy(ghost, 0.5f);
            yield return new WaitForSeconds(ghost_delay);

        }
    }
}

