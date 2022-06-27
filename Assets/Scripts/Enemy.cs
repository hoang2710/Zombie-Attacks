using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _health = 100f;
    private GameObject healthBar;
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
            else
            {
                Die();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar = UIManager.Instance.SetHealthBar(this.tag, transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Die()
    {
        Destroy(healthBar);
        Destroy(gameObject);
    }
}
