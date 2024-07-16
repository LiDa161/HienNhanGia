using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] float max_health;
    [SerializeField] float current_health;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tru_mau(float c)
    {
        current_health -= c;
        print(current_health);
        if (current_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("quai"))
        {
            tru_mau(20);
        }
    }
}
