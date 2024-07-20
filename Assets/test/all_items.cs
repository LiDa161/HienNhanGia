using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class all_items : MonoBehaviour
{
    public List<items_info> all_items_;
    public List<Sprite> all_icons;

    void Awake()
    {
        TextAsset load = Resources.Load<TextAsset>("test_items");
        string[] lines = load.text.Split('\n');

        all_items_ = new List<items_info>();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            items_info a = new items_info();
            a.id = i;
            a.name = cols[1];
            a.description = cols[2];
            a.icons = all_icons[i - 1];
            a.type = Convert.ToInt32(cols[4]);
            a.type = Convert.ToInt32(cols[5]);

            all_items_.Add(a);
        }
    }
}

[System.Serializable]
public class items_
{
    public items_info info;
    public List<items_attribute> atts;
}

[System.Serializable]
public class items_info
{
    public int id;
    public string name;
    public string description;
    public Sprite icons;
    public int type;
    public int rate;
}

[System.Serializable]
public class items_attribute
{
    public int id;
    public string name;
    public string description;
    public Sprite icons;
    public int value;
    public int type;
}
