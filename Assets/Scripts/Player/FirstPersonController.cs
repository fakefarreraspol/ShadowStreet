using System;
using System.Collections;
using UnityEngine;

namespace VRProject.player
{
    public class FirstPersonController : MonoBehaviour
    {
        CharacterController characterController;

        [Header("Stats")]
        [SerializeField]
        private float walkSpeed = 6;
        [SerializeField]
        private float runSpeed = 10;
        [SerializeField]
        private float jumpSpeed = 8;
        [SerializeField]
        private float gravity = 20;

        [Header("Camera")]
        [SerializeField]
        private Camera cam;
        [SerializeField]
        private float mouseH = 3.0f;
        [SerializeField]
        private float mouseV = 2.0f;
        [SerializeField]
        private float minRot = -65.0f;
        [SerializeField]
        private float maxRot = 60.0f;
        [SerializeField]
        private float h_mouse, v_mouse;


        private Vector3 move = Vector3.zero;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            UpdatePlayerMovement();
            UpdateCamera();


        }

        void UpdateCamera()
        {
            h_mouse = mouseH * Input.GetAxis("Mouse X");
            v_mouse += mouseV * Input.GetAxis("Mouse Y");

            v_mouse = Mathf.Clamp(v_mouse, minRot, maxRot);
            cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);

            transform.Rotate(0, h_mouse, 0);

        }
        void UpdatePlayerMovement()
        {
            if (characterController.isGrounded)
            {
                move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

                if (Input.GetKey(KeyCode.LeftShift)) move = transform.TransformDirection(move) * runSpeed;
                else move = transform.TransformDirection(move) * walkSpeed;


                if (Input.GetKey(KeyCode.Space)) move.y = jumpSpeed;

            }

            move.y -= gravity * Time.deltaTime;

            characterController.Move(move * Time.deltaTime);
        }


    }
}