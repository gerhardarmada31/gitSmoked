using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour, IDamagable
{
    [SerializeField] private int health = 5;
    [SerializeField] private UnityEvent restartGame;
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

        if (health <=0)
        {
            restartGame.Invoke();
        }
    }

    IEnumerator IFrameTime()
    {
        isInvunerable = true;
        yield return new WaitForSeconds(0.5f);
        isInvunerable = false;
    }
}
