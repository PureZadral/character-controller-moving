using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermodel : MonoBehaviour
{   
    Transform pBody;
    CharacterController control;
    float mouseX;
    float vertical;
    float horizontal;
    public float speed = 10f;
    float gravityValue = -9.81f;
    public float jumpHeight = 10f;
    bool isGrounded = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pBody = GetComponent<Transform>();
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * 5;
        pBody.Rotate(0, mouseX, 0);
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        control.Move(pBody.forward * vertical * 2 * Time.deltaTime);
        control.Move(pBody.right * horizontal * 2 * Time.deltaTime);
        control.Move(pBody.up * gravityValue * Time.deltaTime);

        if(Input.GetKeyDown("space") && isGrounded == true)
        {
            control.Move(pBody.up * jumpHeight);
        }

        isGrounded = false;
    }

    void OnControllerColliderHit(ControllerColliderHit coll)
    {
        if(coll.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
