using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public AudioSource BigJumpSound;
    public AudioSource JumpSound;

    public Camera MainCamera;
    public AudioClip pickupClip;
    public AudioSource PickUpSound;
    //private bool startMove = false;
    public float speed = 3.0F;
    public float jumpSpeed = 3.0F;
    public float longJumpSpeed = 6.0F;
    public float gravity = 9.8F;
    private bool is_long_jump = false;

    //public float vetcor_coefficient = 0.1f;
    private Vector3 moveDirection = Vector3.zero;

    private Quaternion _last_rotate;
    private Quaternion m_current_rotate;
    private Quaternion _current_rotate {
        get { return m_current_rotate; }
        set
        {
            m_step_t = 0.0f;
            m_current_rotate = value;
        }
    }
    private float m_step_t;

    private void Awake()
    {
        _last_rotate = transform.rotation;
        _current_rotate = transform.rotation;
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        if (!ui_time.ui_t.game_open) return;

        CharacterController controller = GetComponent<CharacterController>();
        Animator ani = this.transform.GetComponentInChildren<Animator>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = MainCamera.transform.TransformVector(moveDirection);
            moveDirection *= speed;
            transform.LookAt(moveDirection + transform.position);

            //if (moveDirection.x != 0.0f || moveDirection.z != 0.0f)
            // {
            //     _current_rotate = Quaternion.LookRotation(moveDirection);
            //     _last_rotate = m_current_rotate;
            // }
            // transform.rotation = Quaternion.Slerp(_last_rotate, _current_rotate, m_step_t);

            // if (m_step_t >= 1.0f)
            //     _last_rotate = m_current_rotate;
            // else
            //     m_step_t += 0.1f;

            if (is_long_jump == true)
            {
                moveDirection.y = longJumpSpeed;
                is_long_jump = false;
                /**触发旋转动画**/
                ani.SetBool("jump", true);
                BigJumpSound.Play();
            } else if (Input.GetButton("Jump")&&!is_long_jump)
            {
                moveDirection.y = jumpSpeed;
                JumpSound.Play();
            }
        }
        else
        {
            var vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            vec = MainCamera.transform.TransformVector(vec);
            transform.LookAt(vec + transform.position);
            vec *= speed;
            moveDirection.x = vec.x;
            moveDirection.z = vec.z;
            ani.SetBool("jump", false);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void LongJump()
    {
        is_long_jump = true;
    }

    public bool IsJump()
    {
        return !GetComponent<CharacterController>().isGrounded;
    }
}

