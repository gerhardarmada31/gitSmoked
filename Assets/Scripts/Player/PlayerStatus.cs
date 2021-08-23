using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamagable
{
    [SerializeField] private int health = 5;
    public Player_SO player;



    //CONST
    public int myCoin { get; set; }
    private bool isInvunerable = false;
    public bool IsPlayerDash { get; set; }

    private void Awake()
    {
        
    }


    public void TakeDamage(int damage)
    {
        if (isInvunerable == false)
        {
            health -= damage;
            StartCoroutine(IFrameTime());
        }
    }

    IEnumerator IFrameTime()
    {
        isInvunerable = true;
        yield return new WaitForSeconds(2f);
        isInvunerable = false;
    }
}
