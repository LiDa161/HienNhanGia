using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    [SerializeField] Image health_;
    [SerializeField] TextMeshProUGUI value_text;
    [SerializeField] float fill_speed;
    public float max_health;
    public float current_health;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        update_health();
    }

     public void update_health()
    {
        float health_bar = current_health / max_health;
        health_.DOFillAmount(health_bar, fill_speed);
        value_text.text = current_health.ToString() + " / " + max_health.ToString();
    }

    public void tru_mau(int tru_mau)
    {
        current_health -= tru_mau;
        current_health = Mathf.Clamp(current_health, 0f, max_health);
        Debug.Log($"da tru : {tru_mau}");
        Debug.Log($"luong hp con lai : {current_health}");
        update_health();
    }
    
    public void tang_mau(int tang_mau)
    {
        current_health += tang_mau;
        current_health = Mathf.Clamp(current_health, 0f, max_health);
        Debug.Log($"da tang : {tang_mau}");
        Debug.Log($"hp moi : {current_health}");
        update_health();
    }
}
