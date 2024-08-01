using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    Rigidbody2D rigid;

    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }
}
