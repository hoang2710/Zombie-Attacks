using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _health = 100;
    private int maxHealth = 100;
    private HealthBar healthBar;
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float attackRate = 2f;
    private float timer;
    private Player player;
    [SerializeField]
    private float moveSpeed = 1.5f;
    private Vector3 targetPos;
    public bool isHealthBarVisible = true;
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
            UIManager.Instance.SpawnDamagePopUp(transform, damage, 1);
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
        if (isHealthBarVisible)
        {
            healthBar = UIManager.Instance.SetHealthBar(transform, 1).GetComponent<HealthBar>();
            healthBar.SetHealthValue(_health);
            healthBar.SetMaxHealthValue(maxHealth);
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPos = player.transform.position + (transform.position - player.transform.position).normalized * 1.5f;

        timer = Time.time;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
        if (transform.position == targetPos && Time.time > timer)
        {
            player.Health -= damage;
            timer = Time.time + attackRate;
        }
    }

    void Die()
    {
        Destroy(healthBar.gameObject);
        Destroy(gameObject);
    }
}
