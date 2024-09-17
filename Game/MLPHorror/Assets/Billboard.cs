using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTransform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
