using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 200f; 
    public Transform playerBody;
    float xRotation = 0f;
    float rotoX = 0f;
    float rotoY = 0f;

    [SerializeField] GameObject[] inputs;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
         
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotoX += mouseX;
        rotoY += mouseY;
        if (rotoX > 30f){
            mouseX = 0f;
            rotoX = 30f;
        }
        if (rotoX < -30f){
            mouseX = 0f;
            rotoX = -30f;
        }
        if (rotoY > 30f){
            mouseY = 0f;
            rotoY = 30f;
        }
        if (rotoY < -30f){
            mouseY = 0f;
            rotoY = -30f;
        }
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 30f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
