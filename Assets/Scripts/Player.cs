using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float LerpRotateSmooth = 5f;
    private HealthBar healthBar;
    public Gun gun;
    [SerializeField]
    private int _health = 200;
    [SerializeField]
    private int maxHealth = 200;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            UIManager.Instance.SpawnDamagePopUp(transform, _health - value, 0);
            _health = value;
            healthBar.SetHealthValue(value);
            if (_health <= 0)
            {
                GameManager.Instance.ChangeGameState(GameManager.GameState.GameOver);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar = UIManager.Instance.SetHealthBar(transform, 0).GetComponent<HealthBar>();
        healthBar.SetMaxHealthValue(maxHealth);
        healthBar.SetHealthValue(_health);
    }



    // Update is called once per frame
    void Update()
    {
        // Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, ConstValue.LAYER_MASK_PLAYER_POINTING);


        // this.transform.LookAt(hit.point);

        Vector3 mouseDirection = hit.point - transform.position;
        float angle = Mathf.Atan2(mouseDirection.x, mouseDirection.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * LerpRotateSmooth);


        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);

        //fire weapon
        if (Input.GetMouseButton(0))
        {
            gun.Fire();
        }

    }
}
