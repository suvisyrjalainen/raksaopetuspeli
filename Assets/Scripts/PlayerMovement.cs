using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour//,IUpdateSelectedHandler,IPointerDownHandler, IPointerUpHandler
{
    public CharacterController controller;

    public Canvas Liikkuminen;

    public Button MoveForward;

    public float moveSpeed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 30f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 move;

    public Animator anim;

    public Vector3 point;

    public bool isPressed;


    // Start is called before the first frame update
    void Start()

    {
        anim = GetComponentInChildren<Animator>();

        controller = GetComponent<CharacterController>();
    }

    /*public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("You have clicked the button!");
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }*/

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        move = transform.right * 0 + transform.forward * zAxis;

        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);

        //transform.localRotation = Quaternion.Euler(xAxis, 0f, 0f);
        //transform.Rotate(Vector3.up * xAxis);

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(point, Vector3.up, 30 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(point, -Vector3.up, 30 * Time.deltaTime);
        }

        //anim.SetInteger("KavelyCheck", 1);
        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetInteger("KavelyCheck", 1);
        }
        else
        {
            anim.SetInteger("KavelyCheck", 0);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}

