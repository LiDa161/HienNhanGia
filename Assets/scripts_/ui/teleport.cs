using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class teleport : MonoBehaviour
{
    Animator ani;
    float time;
    [SerializeField] Transform destination;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ani = collision.GetComponent<Animator>();
            if (Vector2.Distance(collision.transform.position, transform.position) > 0.3f)
            {
                StartCoroutine(port(collision));
            }
        }        
    }

    IEnumerator port(Collider2D col)
    {
        ani.Play("pl_inport");
        game_manager.instance.play_sfx("port_a");
        yield return new WaitForSeconds(0.5f);
        col.transform.position = destination.position;
        ani.Play("pl_outport");
        game_manager.instance.play_sfx("port_b");
        yield return new WaitForSeconds(0.5f);
        ani.Play("movement_");
    }   
}
