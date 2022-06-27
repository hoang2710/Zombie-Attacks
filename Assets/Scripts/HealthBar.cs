using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    [SerializeField]
    private Vector3 healthUIOffset;
    private Transform objectTransform;
    private string objectTag;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(FindObjectTransform());
        StartCoroutine(UpdateLookAtCamera());

    }

    void Update()
    {
        transform.position = objectTransform.position + healthUIOffset;
    }

    public void SetObjectTag(string tag)
    {
        objectTag = tag;
    }

    IEnumerator UpdateLookAtCamera()
    {
        int i = 60; //number of frame to update
        while (i-- >= 0)
        {
            transform.LookAt(transform.position - Camera.main.transform.position); //????
            yield return null;
        }
    }

    IEnumerator FindObjectTransform()
    {
        while (objectTransform == null)
        {
            if (objectTag != null)
            {
                objectTransform = GameObject.FindGameObjectWithTag(objectTag).transform;
            }
            Debug.Log("Player found");
            yield return null;
        }
    }
}
