using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Vector3 healthUIOffset;
    private Transform objectTransform;
    private string objectTag;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        StartCoroutine(UpdateLookAtCamera());

    }

    void Update()
    {
        transform.position = objectTransform.position + healthUIOffset;
    }

    public void SetObjectTransform(Transform trans)
    {
        objectTransform = trans;
    }

    public void SetHealthValue(int val)
    {
        healthBar.value = val;
    }

    public void SetMaxHealthValue(int val)
    {
        healthBar.maxValue = val;
    }

    IEnumerator UpdateLookAtCamera()
    {
        int i = 10; //number of frame to update
        while (i-- >= 0)
        {
            transform.LookAt(transform.position - Camera.main.transform.position); //????
            yield return null;
        }
    }

}
