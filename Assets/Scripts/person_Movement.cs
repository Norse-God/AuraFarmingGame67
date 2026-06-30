using UnityEngine;

public class person_Movement : MonoBehaviour
{
    [Header("Move speeds (m/s)")]
    public float walkSpeed = 1.6f;
    public float runSpeed = 4.5f;
    public float backSpeed = 1.3f;
    public float strafeSpeed = 1.6f;


    public float turnSpeed = 180f;
    public float gravity = -20f;
    

    public KeyCode runKey = KeyCode.LeftShift;

    Rigidbody rb;
    Animator _anim;
    CharacterController _cc;
    float _verticalVel;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        bool running = Input.GetKey(runKey);


        int move;
        if (Mathf.Abs(moveX) < 0.1f && Mathf.Abs(moveY) < 0.1f)
            move = 0;
        else if (Mathf.Abs(moveY) >= Mathf.Abs(moveX))
            move = moveY > 0f ? (running ? 2 : 1) : (running ? 4 : 3);
        else
            move = moveX > 0f ? 6 : 5;
        _anim.SetInteger("Move", move);


        //Свич для смены стейта аниматора
        Vector3 planar = move switch
        {
            1 => transform.forward * walkSpeed,
            2 => transform.forward * runSpeed,
            _ => Vector3.zero,
        };

        if (_cc.isGrounded && _verticalVel < 0f) _verticalVel = -2f;
        _verticalVel += gravity * Time.deltaTime;

        Vector3 velocity = planar + Vector3.up * _verticalVel;
        _cc.Move(velocity * Time.deltaTime);

        float yaw = Input.GetAxis("Mouse X");
        if (Mathf.Abs(yaw) < 0.01f)
        {
            if (Input.GetKey(KeyCode.Q)) yaw = -1f;
            else if (Input.GetKey(KeyCode.E)) yaw = 1f;
        }
        transform.Rotate(0f, yaw * turnSpeed * Time.deltaTime, 0f);

     
    }
}
