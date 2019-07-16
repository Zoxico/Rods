using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 15.0f;
    [SerializeField] private float angle = 65.0f;

    void Start()
    {
        transform.Rotate(Vector3.right * angle, Space.World);
        //Debug.Log(transform.rotation.x);
    }

    void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.Self);
	}
}
