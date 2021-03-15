using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace roguelike.Player
{
    public class PlayerScript : MonoBehaviour
    {
        public Camera cam;
        Rigidbody2D rb;
        PlayerInputActions _playerInput;
        Vector2 playerMovementInput;
        Vector2 mouseRawData;
        Vector2 mousePos;
        
        float defaultMoveSpeed;
        public float moveSpeed;
        public float dashSpeed;
        bool spacePressed;
        bool lShiftPressed;



        void Awake()
        {
            _playerInput = new PlayerInputActions();
            rb = this.GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            defaultMoveSpeed = moveSpeed;
        }

        void OnEnable()
        {
            _playerInput.Enable();
            //_playerInput.Player.Movement.Enable();
            //_playerInput.Player.Skill.Enable();
            //_playerInput.Player.MouseAim.Enable();
            //_playerInput.Player.Dash.Enable();

        }
        void OnDisable()
        {
            _playerInput.Disable();
            //_playerInput.Player.Movement.Disable();
            //_playerInput.Player.Skill.Disable();
            //_playerInput.Player.MouseAim.Disable();
            //_playerInput.Player.Dash.Disable();
        }
        // Update is called once per frame
        void Update()
        {
            playerMovementInput = _playerInput.Player.Movement.ReadValue<Vector2>();
            mouseRawData = _playerInput.Player.MouseAim.ReadValue<Vector2>();
            mousePos = cam.ScreenToWorldPoint(mouseRawData);

            if(_playerInput.Player.Dash.ReadValue<float>() == 1)
            {
                moveSpeed = dashSpeed;
            } else { moveSpeed = defaultMoveSpeed; }

            if(_playerInput.Player.Skill.ReadValue<float>() == 1)
            {
                print("Karcheese a skill has been activated");
            }
            if(_playerInput.Player.Interact.ReadValue<float>() == 1)
            {
                print("owo we shooting goo");
            }


        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + playerMovementInput * moveSpeed * Time.fixedDeltaTime);

        }
    }
}
