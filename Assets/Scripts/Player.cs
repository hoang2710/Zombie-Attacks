using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float LerpRotateSmooth = 5f;
    const int LAYER_MASK_6 = 1 << 6;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, LAYER_MASK_6);

        if (hit.transform != null)
        {

            // this.transform.LookAt(hit.point);

            Vector3 mouseDirection = hit.point - transform.position;
            float angle = Mathf.Atan2(mouseDirection.x, mouseDirection.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * LerpRotateSmooth);

        }
        Debug.DrawRay(ray.origin, ray.direction*hit.distance, Color.yellow);

    }
}
