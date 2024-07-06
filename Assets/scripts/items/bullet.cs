using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
