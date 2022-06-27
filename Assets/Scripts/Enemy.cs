using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _health = 100;
    private int maxHealth = 100;
    private HealthBar healthBar;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            int damage = _health - value;
            Debug.Log("trigger damage  " + damage);
            UIManager.Instance.SpawnDamagePopUp(transform, damage);
            _health = value;
            healthBar.SetHealthValue(value);
            if (_health <= 0)
            {
                Die();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar = UIManager.Instance.SetHealthBar(transform).GetComponent<HealthBar>();
        healthBar.SetHealthValue(_health);
        healthBar.SetMaxHealthValue(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Die()
    {
        Destroy(healthBar.gameObject);
        Destroy(gameObject);
    }
}
