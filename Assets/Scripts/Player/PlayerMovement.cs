using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ICollectable
{
    //CONST
    private Animator playerAnim;
    private Vector3 dirInput;
    private Vector3 charaVelocity;
    private bool onGround;
    private bool wasGrounded = false;
    private bool isJumping;
    private PlayerStatus playerStatus;
    private CharacterController charController;
    [SerializeField] private Transform playerMainCam;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravityScale = -40;
    // [SerializeField] private float turnSpeed;
    private int dashCount = 0;
    private int jumpCount = 0;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int maxJump = 1;
    [SerializeField] private int maxDash = 1;
    [SerializeField] private float dashTime = 0.5f;
    private bool isDash = false;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerStatus = GetComponent<PlayerStatus>();
        playerAnim = GetComponent<Animator>();
    }
    public void Move(Vector2 _playerInputs)
    {
        var jumpValue = Mathf.Clamp(charaVelocity.y, -100, 15);
        playerAnim.SetFloat("IdletoRun", _playerInputs.x);
        playerAnim.SetFloat("JumpToFall", jumpValue);
        playerAnim.SetBool("IsJumping", isJumping);

        Vector3 camF = playerMainCam.forward;
        Vector3 camR = playerMainCam.right;
        camF.y = 0;
        camR.y = 0;
        camF.Normalize();
        camR.Normalize();


        dirInput = new Vector3(_playerInputs.x, 0, _playerInputs.y);
        dirInput = dirInput.z * camF + dirInput.x * camR;
        dirInput = Vector3.ClampMagnitude(dirInput, 1);

        //Rotation of Player
        if (charaVelocity.magnitude > 0.01f && dirInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dirInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
        }

        //DO A RAYCAST FORWARD

        //DO A RAYCAST DOWN

        //Init variables
        //Change the X values to Z

        onGround = charController.isGrounded;
        Vector3 movement = dirInput * moveSpeed;
        charaVelocity.y += gravityScale * Time.deltaTime;
        movement.x += charaVelocity.x * Time.deltaTime;
        movement.y = charaVelocity.y;

        if (onGround && charaVelocity.y < 0)
        {
            charaVelocity.y = -3f;
            jumpCount = 0;
            dashCount = 0;
            isJumping = false;

            if (onGround && !wasGrounded)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/Land", GetComponent<Transform>().position);
                wasGrounded = true;
            }
            //groundCheck
        }
        else
        {
            //COYOTE JUMP IF WE HAVE TIME
        }
        charController.Move(movement * Time.deltaTime);
    }

    public void Jump()
    {
        if (onGround || jumpCount < maxJump)
        {
            // isJumping = true;
            isJumping = true;
            wasGrounded = false;
            playerAnim.SetTrigger("Jump");
            jumpCount++;
            charaVelocity.y += Mathf.Sqrt(jumpHeight * -4f * gravityScale);
        }
    }

    public void Dash()
    {
        //DASHTIMER!!!
        if (!isDash && dashCount < maxDash)
        {
            Debug.Log("Dashing!");
            StartCoroutine(DashTimer(dashTime));
            dashCount++;
            charaVelocity.x += dirInput.x * 1200f;
        }
    }

    IEnumerator DashTimer(float _dashTime)
    {
        isDash = true;
        yield return new WaitForSeconds(_dashTime);
        charaVelocity.x = 0;
        isDash = false;
    }

    public void GetCoins(int coins)
    {
        playerStatus.player.coin += coins;
    }
}
