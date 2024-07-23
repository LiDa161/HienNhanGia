using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class health_quai : MonoBehaviour
{

    [SerializeField] TextMeshPro value_text;
    [SerializeField] GameObject damage_text;
    public float max_health;
    public float current_health;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
    }
    
    public void tru_mau(float tru_mau)
    {
        current_health -= tru_mau;
        //GameObject dam_text = Instantiate(damage_text, transform.position, Quaternion.identity);
        value_text.text = tru_mau.ToString();
        //Destroy(dam_text, 1);
        Debug.Log($"da tru : {tru_mau}");
        Debug.Log($"luong hp con lai : {current_health}");
    }
}
