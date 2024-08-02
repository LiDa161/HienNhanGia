using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quai_move : MonoBehaviour
{
    Vector2 direction;
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
    }
}

