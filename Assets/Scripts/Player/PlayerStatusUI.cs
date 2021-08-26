using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatusUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text hpValue;
    [SerializeField] private TMP_Text coinValue;
    private PlayerStatus playerStatus;

    private void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerUI();
    }

     public void PlayerUI()
    {
        hpValue.text = playerStatus.Health.ToString();
        // coinValue.text = playerStatus
        coinValue.text = playerStatus.player.coin.ToString();
    }
}
