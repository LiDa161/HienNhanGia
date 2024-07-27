using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_pos : MonoBehaviour
{
    [SerializeField] Vector2 cam_pos;
    [SerializeField] Vector2 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam_pos = Camera.main.transform.position;
        dir.x = cam_pos.x - transform.position.x;
        dir.y = cam_pos.y - transform.position.y;

        if (dir.x > 26)
        {
            transform.Translate(Vector2.right * 26 * 2);
        }
        
        if (dir.x < -26)
        {
            transform.Translate(Vector2.right * -26 * 2);
        }
        
        if (dir.y > 16)
        {
            transform.Translate(Vector2.up * 16 * 2);
        }
        
        if (dir.y < -16)
        {
            transform.Translate(Vector2.up * -16 * 2);
        }
        
    }
}
