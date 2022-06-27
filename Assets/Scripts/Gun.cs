using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Transform gunPoint;
    [SerializeField]
    Transform gunBase;
    float _damage = 10f;
    public float Damage
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
    public void Fire()
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
    }


}
