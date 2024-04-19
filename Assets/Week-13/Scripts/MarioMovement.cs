using Maze;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MarioAnimations
{
    public class MarioMovement : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float jumpForce;
        [SerializeField] float rotationVertical = 5.0f;
        [SerializeField] float rotationHorizontal = 5.0f;

        private float mouseDeltaX = 0f;
        private float mouseDeltaY = 0f;
        private float cameraRotX = 0f;
        private int rotDir = 0;
        private bool grounded;

        InputAction move;
        InputAction jump;
        InputAction look;

        PlayerControllerMappings playerMappings;

        Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerMappings = new PlayerControllerMappings();

            move = playerMappings.Player.Move;

            jump = playerMappings.Player.Jump;
            jump.performed += Jump;

            look = playerMappings.Player.Look;
        }

        private void OnEnable()
        {
            move.Enable();
            jump.Enable();
            look.Enable();
        }
        private void OnDisable()
        {
            move.Disable();
            jump.Disable();
            look.Disable();
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }
        private void Update()
        {
            HandleHorizontalRotation();
            HandleVerticalRotation();
        }
        void HandleHorizontalRotation()
        {
            mouseDeltaX = look.ReadValue<Vector2>().x;

            if (mouseDeltaX != 0)
            {
                rotDir = mouseDeltaX > 0 ? 1 : -1;

                transform.eulerAngles += new Vector3(0, rotationHorizontal * Time.deltaTime * rotDir, 0);
            }
        }

        void HandleVerticalRotation()
        {
            mouseDeltaY = look.ReadValue<Vector2>().y;

            if (mouseDeltaY != 0)
            {
                rotDir = mouseDeltaY > 0 ? -1 : 1;

                cameraRotX += rotationVertical * Time.deltaTime * rotDir;
                cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);

                var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);

                //Vector3 angle = new Vector3(rotation * Time.deltaTime * rotDir, 0, 0);

                Camera.main.transform.localRotation = targetRotation;
                //Camera.main.transform.Rotate(angle, Space.Self);
            }
        }
        void FixedUpdate()
        {
            grounded = IsGrounded();
            Vector2 input = move.ReadValue<Vector2>();
            Vector3 direction = (input.x * transform.right) + (transform.forward * input.y);

            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
        void Jump(InputAction.CallbackContext context)
        {
            Debug.Log($"{grounded}");
            if (grounded == false) return;
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        bool IsGrounded()
        {
            int layerMask = 1 << 3;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -2), out hit, 1.1f, layerMask))
            {
                // use Debug.DrawRay to visualize the ray
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

