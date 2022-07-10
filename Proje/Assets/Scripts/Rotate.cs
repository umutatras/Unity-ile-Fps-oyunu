using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 rotateAxis;
    public void Update()
    {
        transform.Rotate(rotateAxis * speed * Time.deltaTime);
    }
}
