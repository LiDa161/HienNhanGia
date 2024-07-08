using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float fire_force = 10f;
    Vector3 mouse_position;
    Camera camera;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mouse_position = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouse_position - transform.position;
        Vector3 rotation = transform.position - mouse_position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * fire_force;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("quai"))
        {
            var name = collision.attachedRigidbody.name;
            Destroy(gameObject);
            Destroy(GameObject.Find(name));
            Debug.Log("done");
        }
    }

}
