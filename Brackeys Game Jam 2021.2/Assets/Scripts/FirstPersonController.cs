using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float rotateSpeed;
    public float maximumRotation;
    public GameObject playerCamera;
    
    private Keyboard keyboard;
    private Rigidbody rb;
    private float xAngle = 0;

    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        keyboard = Keyboard.current;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Jump
        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
        {
            isGrounded = false;
            Vector3 jump = new Vector3(0, jumpForce, 0);
            rb.AddForce(jump, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (keyboard == null)
        {
            Debug.Log("Keyboard Not Found");
            return;
        }

        // Movement
        if (keyboard.wKey.isPressed)
        {
            Vector3 move = new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.deltaTime));
            rb.MovePosition(move);
        }

        if (keyboard.sKey.isPressed)
        {
            Vector3 move = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime));
            rb.MovePosition(move);
        }

        // Rotation
        if (keyboard.qKey.isPressed && xAngle > -maximumRotation)
        {
            Vector3 rotate = new Vector3(transform.rotation.eulerAngles.x - (rotateSpeed * Time.deltaTime), transform.rotation.eulerAngles.y, 0);
            playerCamera.transform.Rotate(rotate, Space.World);
            xAngle -= (rotateSpeed * Time.deltaTime);
        }

        if (keyboard.eKey.isPressed && xAngle < maximumRotation)
        {
            Vector3 rotate = new Vector3(transform.rotation.eulerAngles.x + (rotateSpeed * Time.deltaTime), transform.rotation.eulerAngles.y, 0);
            playerCamera.transform.Rotate(rotate, Space.World);
            xAngle += (rotateSpeed * Time.deltaTime);
        }

        if (keyboard.aKey.isPressed)
        {
            Quaternion rotate = Quaternion.Euler(0, transform.rotation.eulerAngles.y - (rotateSpeed * Time.deltaTime), 0);
            rb.MoveRotation(rotate);
        }

        if (keyboard.dKey.isPressed)
        {
            Quaternion rotate = Quaternion.Euler(0, transform.rotation.eulerAngles.y + (rotateSpeed * Time.deltaTime), 0);
            rb.MoveRotation(rotate);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
