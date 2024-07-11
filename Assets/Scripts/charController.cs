using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{

    public float speed = 5.0f;
    public float jumpSpeed = 7.0f;
    public float gravity = 20.0f;
    public float interactRange = 2.0f;


    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //player Movment
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            //Jump
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

            //Interact
            if(Input.GetButton("Interact"))
            {
                // Interact();
            }
        }


        //gravity
        moveDirection.y -= gravity * Time.deltaTime;


        //movement of controller
        controller.Move(moveDirection * Time.deltaTime);


        // void Interact()
        // {
        //     Ray ray = new Ray(transform.position, transform.forward);
        //     RaycastHit hit;

        //     if(Physics.Raycast(ray, out hit, interactRange))
        //     {
        //         Interactable interact = hit.collider.GetComponent<Interactable>();
        //         if(interact !=null)
        //         {
        //             interact.Interact();
        //         }

        //     }
        // }



    }
}
