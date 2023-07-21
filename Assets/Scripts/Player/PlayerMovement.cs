using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public GameObject cameraPosition;

    Vector3 velocity, move;
    Camera camera;
    float horizontal, vertical, gravity = -9.81f, sphereRadius = 0.3f;
    bool isGrounded;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (!GameManager.Instance.gameOver && !GameManager.Instance.winner)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            move = new Vector3(horizontal, 0, vertical);

            cameraPosition.transform.SetParent(null);

            //transform.LookAt(transform.position + new Vector3(horizontal, 0, vertical));
            playerRotation();

            cameraPosition.transform.SetParent(transform);

            characterController.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }

    private void playerRotation()
    {
        Vector3 positionOnScreen = camera.WorldToViewportPoint(transform.position);
        Vector3 mouseOnScreen = camera.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = mouseOnScreen - positionOnScreen;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;

        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
    }
}
