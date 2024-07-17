using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float max_health;
    public float current_health;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tru_mau(float tru_mau)
    {
        current_health -= tru_mau;
        Debug.Log($"da tru : {tru_mau}");
        Debug.Log($"luong hp con lai : {current_health}");
        
    }
    
    public void tang_mau(float tang_mau)
    {
        current_health += tang_mau;
        Debug.Log($"da tang : {tang_mau}");
        Debug.Log($"hp moi : {current_health}");
    }
}
