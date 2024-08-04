using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI scoretext;
   
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void setText(string txt)
    {
        scoretext.text = txt;
    }
}
