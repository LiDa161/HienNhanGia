using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class health_quai : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI value_text;
    public float max_health;
    public float current_health;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
    }

    public void update_health()
    {
        value_text.text = current_health.ToString();
    }

    public void tru_mau(float tru_mau)
    {
        current_health -= tru_mau;
        Debug.Log($"da tru : {tru_mau}");
        Debug.Log($"luong hp con lai : {current_health}");
        update_health();
    }
}
