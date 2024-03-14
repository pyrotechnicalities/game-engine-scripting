using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

namespace Maze
{
    public class Week6Demo : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float jumpForce;
        [SerializeField] float rotationVertical = 5.0f;
        [SerializeField] float rotationHorizontal = 5.0f;

        private float mouseDeltaX = 0f;
        private float mouseDeltaY = 0f;
        private float cameraRotX = 0f;
        private int rotDir = 0;
        private int playerHealth = 100;
        private int numCoins = 0;
        private int numKeys = 0;
        private bool hasKeys = false;
        private bool grounded;

        [SerializeField] private DoorTrigger trigger;
        [SerializeField] GameObject winLabel;
        [SerializeField] TextMeshProUGUI hpLabel;
        [SerializeField] TextMeshProUGUI coinsLabel;
        [SerializeField] TextMeshProUGUI keysLabel;

        InputAction move;
        InputAction fire;
        InputAction jump;
        InputAction look;

        PlayerControllerMappings playerMappings;

        Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerMappings = new PlayerControllerMappings();

            move = playerMappings.Player.Move;

            fire = playerMappings.Player.Fire;
            fire.performed += Fire;

            jump = playerMappings.Player.Jump;
            jump.performed += Jump;

            look = playerMappings.Player.Look;
        }

        private void OnEnable()
        {
            move.Enable();
            fire.Enable();
            jump.Enable();
            look.Enable();
        }
        private void OnDisable()
        {
            move.Disable();
            fire.Disable();
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

                Debug.Log(Camera.main.transform.localRotation.x);

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
            if (numKeys >= 1)
            {
                hasKeys = true;
            }
        }
        void Fire(InputAction.CallbackContext context)
        {

        }
        void Jump(InputAction.CallbackContext context)
        {
            if (grounded == false) return;
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump!");
        }
        bool IsGrounded()
        {
            int layerMask = 1 << 3;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask))
            {
                // use Debug.DrawRay to visualize the ray
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Damage()
        {
            // hit trap
            Debug.Log("Player has been damaged");
            playerHealth = playerHealth - 5;
            hpLabel.text = string.Format("HP: {0}", playerHealth);
        }
        private void AddCoin()
        {
            // hit coin
            numCoins++;
            coinsLabel.text = string.Format("Coins: {0}", numCoins);
        }
        private void AddKey()
        {
            // hit key
            numKeys++;
            keysLabel.text = string.Format("Keys: {0}", numKeys);
        }
        private void WinGame()
        {
            winLabel.SetActive(true);
        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Player has entered a trigger");
            if (other.transform.tag == "Goal") WinGame();
            if (other.transform.tag == "Door" && hasKeys == true) trigger.Open();
            if (other.transform.tag == "Trap") Damage();
            if (other.transform.tag == "Coin") AddCoin();
            if (other.transform.tag == "Key") AddKey();
        }
    }
}
