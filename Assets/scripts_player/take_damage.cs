using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class take_damage : MonoBehaviour
{
    public static take_damage instance;
    public List<set_dmg> show_dmg;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        foreach(Transform dmg in transform)
        {
            show_dmg.Add(dmg.GetComponent<set_dmg>());
        }
    }

    public void show(float damage_, Vector3 pos)
    {
        var get = show_dmg.FirstOrDefault(x => !x.gameObject.activeSelf);
        if(get != null)
        {
            get.set_dmg_(damage_);
            get.transform.position = pos;
            get.gameObject.SetActive(true);
            StartCoroutine(delay(get.gameObject));
        }
    }

    IEnumerator delay(GameObject game)
    {
        yield return new WaitForSeconds(1.5f);
        game.SetActive(false);
    }
}
