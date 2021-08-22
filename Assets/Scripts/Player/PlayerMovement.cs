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

    [SerializeField] private int jumpCount = 0;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int maxJump = 1;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerStatus = GetComponent<PlayerStatus>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    public void Move(Vector2 _playerInputs)
    {

        //DO A RAYCAST FORWARD

        //DO A RAYCAST DOWN

        //Init variables
        dirInput = new Vector3(_playerInputs.x, 0, _playerInputs.y);

        onGround = charController.isGrounded;
        Vector3 movement = dirInput * moveSpeed;
        charaVelocity.y += gravityScale * Time.deltaTime;
        movement.y = charaVelocity.y;

        if (onGround && charaVelocity.y < 0)
        {
            charaVelocity.y = -3f;
            jumpCount = 0;
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

    public void GetCoins(int coins)
    {
        playerStatus.myCoin += coins;
    }
}
