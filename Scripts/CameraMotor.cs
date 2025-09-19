using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    private Vector3 offset = new Vector3(0, 0, -7.5f);

    // Start is called before the first frame update
    void Start()
    {

    }
    void LateUpdate()
    {
        transform.position = lookAt.transform.position + offset;
    }
}
