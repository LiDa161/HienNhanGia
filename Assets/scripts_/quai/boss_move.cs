using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_move : MonoBehaviour
{
    Vector2 dir;
    Transform pl_trans;
    Animator ani;
    quai_atk quai_Atk;
    float distance;
    [SerializeField] float move_speed, radius;
    [SerializeField] bool is_atk;

    // Start is called before the first frame update
    void Start()
    {  
        quai_Atk = GetComponentInChildren<quai_atk>();
        ani = GetComponent<Animator>();

        var player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            player = FindObjectOfType<GameObject>();
        }
        else
        {
            pl_trans = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pl_trans != null && !is_atk)
        {
            dir = (pl_trans.position - transform.position).normalized;
            transform.Translate(dir * move_speed * Time.deltaTime);
            ani.SetFloat("speed_", move_speed);
        }
        else
        {
            ani.SetFloat("speed_", 0);
        }

        if (dir != Vector2.zero)
        {
            ani.SetFloat("x.velocity", dir.x);
            ani.SetFloat("y.velocity", dir.y);
        }       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            distance = Vector2.Distance(transform.position, collision.transform.position);
            print(distance);
            if (distance <= radius)
            {
                is_atk = true;
                quai_Atk.fire();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            is_atk = false;
        }
    }
    /*Vector2 direction;
    Animator ani;
    Transform player;
    [SerializeField] float speed = 2f, radius = 5f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < radius)
        {
            direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            ani.SetFloat("speed_", speed);
        }
        else if (distance > radius)
        {
            Destroy(gameObject, 1f);
        }
        else
        {
            ani.SetFloat("speed_", 0);
        }

        if (direction != Vector2.zero)
        {
            ani.SetFloat("x.velocity", direction.x);
            ani.SetFloat("y.velocity", direction.y);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }*/
}
