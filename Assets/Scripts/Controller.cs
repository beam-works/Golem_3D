using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Quaternion targetRotation;
    [SerializeField] Animator anim;
    private Rigidbody rb;
    public float jumpPower;
    private bool isJumping = false;

    void Awake()
    {
        //?R???|?[?l???g???A?t??
        TryGetComponent(out anim);

        //??????
        targetRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked; //?}?E?X?J?[?\???????b?N

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //?????x?N?g????????
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        var velocity = horizontalRotation * new Vector3(horizontal, 0, vertical).normalized;


        if (!isJumping && Input.GetKeyDown("space"))
        {
            anim.SetBool("isJumping", true);
            rb.velocity = Vector3.up * jumpPower;
        }


        //???x??????
        var speed = Input.GetKey(KeyCode.LeftShift) ? 2: 1;
        var rotationSpeed = 600 * Time.deltaTime;

        //??????????????
        if( velocity.magnitude > 0.5f)
        {
            targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);

        //???????x??Animatior?????h
        anim.SetFloat("Speed", velocity.magnitude * speed, 0.1f, Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJumping", false);
        }

    }
     
}