using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _health = 100f;
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (_health > 0)
            {
                _health = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
