using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2f; // 이동 속도
    public float rotateSpeed = 150f; // 회전 속도
    public Vector3 initialPosition; // Initial position of the player
    public Quaternion initialRotation; // Initial rotation of the player

    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator;


    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        initialPosition = transform.position; // Store the initial position
        initialRotation = transform.rotation; // Store the initial rotation
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if the player's y-position is below -10
        if (transform.position.y < -10)
        {
            // Reset the player's position and rotation to the initial values
            playerRigidbody.position = initialPosition;
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            playerRigidbody.rotation = initialRotation;
        }
        else
        {
            // Handle player movement and rotation as before
            Vector3 movement = new Vector3(-horizontalInput, 0f, -verticalInput);
            movement.Normalize();
            movement = transform.TransformDirection(movement);
            playerRigidbody.MovePosition(playerRigidbody.position + (-movement) * moveSpeed * Time.deltaTime);

            float turn = horizontalInput * rotateSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            playerRigidbody.MoveRotation(playerRigidbody.rotation * turnRotation);

            if (movement.magnitude > 0)
            {
                playerAnimator.SetTrigger("Walk");
            }
            else
            {
                playerAnimator.ResetTrigger("Walk");
            }
        }
    }
}
