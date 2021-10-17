using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frogy : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    Canvas frogyCanvas;

    float jumpTimer = 0.0f;
    [SerializeField]
    float maxJump = 1.0f;
    [SerializeField]
    float jumpStrength = 1.0f;

    [SerializeField]
    float turnSpeed = 10.0f;

    bool isRotatingLeft = false;
    bool isRotatingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Start Jump
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            // Increase Jump Time
            jumpTimer += Time.deltaTime;

            jumpTimer = Mathf.Clamp(jumpTimer, 0, maxJump);

            float jumpPercentage = jumpTimer / maxJump;

            // scale based on percent
            frogyCanvas.transform.localScale = new Vector3(1, 1 - (0.5f * jumpPercentage), 1);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            // Jump
            rb.AddRelativeForce(new Vector3(0.0f, jumpTimer * jumpStrength, jumpTimer * jumpStrength), ForceMode.Impulse);
            frogyCanvas.transform.localScale = new Vector3(1, 1, 1);
            jumpTimer = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Rotate left
            isRotatingLeft = true;
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            isRotatingLeft = false;
        }

        if(Input.GetKey(KeyCode.D))
        {
            // Rotate right
            isRotatingRight = true;
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            isRotatingRight = false;
        }
    }

    private void FixedUpdate()
    {
        if(isRotatingLeft)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0.0f, -turnSpeed, 0.0f) * Time.fixedDeltaTime);
            rb.MoveRotation(deltaRotation * rb.rotation);
        }
        else if(isRotatingRight)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0.0f, turnSpeed, 0.0f) * Time.fixedDeltaTime);
            rb.MoveRotation(deltaRotation * rb.rotation);
        }
    }
}
