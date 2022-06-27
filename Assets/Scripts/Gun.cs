using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform gunPoint;
    [SerializeField]
    private Transform gunBase;
    [SerializeField]
    private float fireRate = 0.15f;
    private float timer;
    private int _damage = 10;
    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            if (value > 0)
            {
                _damage = value;
            }
        }
    }

    void Start()
    {
        timer = Time.time;
    }
    public void Fire()
    {
        if (Time.time > timer)
        {
            RaycastHit hit;
            Ray ray = new Ray(gunBase.position, gunPoint.position - gunBase.position);
            Physics.Raycast(ray, out hit, Mathf.Infinity, ConstValue.LAYER_MASK_ENEMY);
            Debug.DrawRay(gunBase.position, hit.point - gunBase.position, Color.green, 2f);

            if (hit.transform != null)
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                enemy.Health -= _damage;
            }

            timer = Time.time + fireRate;
        }
    }


}
