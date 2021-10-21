using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLilypad : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 5;

    [SerializeField]
    GameObject referencePos;

    [SerializeField]
    Rigidbody lilypad;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }

    private void FixedUpdate()
    {
        lilypad.MovePosition(referencePos.transform.position);
    }
}
