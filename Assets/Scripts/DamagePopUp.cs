using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    [SerializeField]
    private TMP_Text damageText;
    [SerializeField]
    private float minPopDistance;
    [SerializeField]
    private float maxPopDistance;
    [SerializeField]
    private float lifeTime = 1f;
    private float timer = 0f;
    private float disappearTime;
    private Vector3 targetPos;
    [SerializeField]
    private Vector3 offSet;
    void Start()
    {
        // damageText = GetComponent<TMP_Text>();

        transform.LookAt(transform.position - Camera.main.transform.position);

        float ranDistance = Random.Range(minPopDistance, maxPopDistance);
        float ranDirection = Random.rotation.eulerAngles.y;
        targetPos =transform.position + (Quaternion.Euler(0, ranDirection, 0) * new Vector3(ranDistance, 0, ranDistance));

        disappearTime = lifeTime / 2;

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > disappearTime)
        {
            damageText.color = Color.Lerp(damageText.color, Color.clear, (timer - disappearTime) / disappearTime);
        }

        if (timer > lifeTime)
        {
            Destroy(gameObject);
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, timer / lifeTime);

    }

    public void SetDamageText(int damage)
    {
        damageText.text = damage.ToString();
    }
}
