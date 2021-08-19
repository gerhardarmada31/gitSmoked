using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //CONST
    private Vector2 moveInputs;
    private Vector2 charaVelocity;
    private bool isGround; 
    private CharacterController charController;

    [SerializeField] private Transform playerMainCam;


    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int jumpCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 _playerInputs)
    {


        //Init variables
        moveInputs = new Vector2(_playerInputs.x, _playerInputs.y);

        //Rotation of Player
        if (true)
        {
            
        }
    }
}
