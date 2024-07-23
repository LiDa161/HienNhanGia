using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class set_dmg : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI damage_text;
    public void set_dmg_(float dmg)
    {
        damage_text.text = dmg.ToString();
    }
}
