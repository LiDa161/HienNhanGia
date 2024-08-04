using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class damage_text : MonoBehaviour
{
    [SerializeField] GameObject prefab_popup;
    //[SerializeField] int min, max;
    [SerializeField] Vector3 ofset = new Vector3(0, 1, 0), random = new Vector3(0.5f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void set_text(int x)
    {
        var popup = Instantiate(prefab_popup, transform.position, Quaternion.identity);
        Destroy(popup, 1f);
        popup.transform.localPosition += ofset;
        popup.transform.localPosition += new Vector3 (Random.Range(-random.x, random.x),
        Random.Range(-random.y, random.y),
        Random.Range(-random.z, random.z));
        popup.GetComponent<TextMeshPro>().text = x.ToString();
    }
}
