using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ICollectable
{
    //CONST
    private Vector3 dirInput;
    private Vector3 charaVelocity;
    private bool onGround;
    private PlayerStatus playerStatus;
    private CharacterController charController;

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
    }
    public void Move(Vector2 _playerInputs)
    {

        //DO A RAYCAST FORWARD

        //DO A RAYCAST DOWN

        //Init variables
        //Change the X values to Z
        dirInput = new Vector3(_playerInputs.x, 0, _playerInputs.y);

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
            jumpCount++;
            charaVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityScale);
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
