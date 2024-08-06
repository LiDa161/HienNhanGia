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
    GameObject player;
    player_move player_Move;
    [SerializeField] float move_speed, radius;
    [SerializeField] bool is_atk;
    [SerializeField] bool delayAtk;

    // Start is called before the first frame update
    void Start()
    {
        quai_Atk = GetComponentInChildren<quai_atk>();
        ani = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        player_Move = FindObjectOfType<player_move>();

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
        dir = (pl_trans.position - transform.position).normalized;
        ani.SetFloat("x.velocity", dir.x);
        ani.SetFloat("y.velocity", dir.y);

        if (pl_trans != null && !is_atk)
        {
            transform.Translate(dir * move_speed * Time.deltaTime);
            ani.SetFloat("speed_", move_speed);
        }
        else
        {
            ani.SetFloat("speed_", 0);
        }


        /*if (dir != Vector2.zero)
        {
            ani.SetFloat("x.velocity", dir.x);
            ani.SetFloat("y.velocity", dir.y);
        }*/

        if (is_atk)
        {
            if (!delayAtk)
            {
                quai_Atk.fire();
                delayAtk = true;
                StartCoroutine(DelayForAttack());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {            
            distance = Vector2.Distance(transform.position, collision.transform.position);
            if (distance <= radius)
            {
                is_atk = true;                
            }
        }
    }

    void move_player()
    {
        //var direction = player.transform.position - transform.position;

        var angle = Mathf.Atan2(player_Move.move_.y, player_Move.move_.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    IEnumerator DelayForAttack()
    {
        yield return new WaitForSeconds(2f);
        delayAtk = false ;
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
