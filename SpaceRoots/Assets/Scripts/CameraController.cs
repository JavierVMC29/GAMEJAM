using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    private float mouseX;
    private float mouseY;

    [SerializeField]
    private float mouseSensitivity = 300.0f;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerBody.Rotate(mouseX * mouseSensitivity * Time.deltaTime * Vector3.up);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
