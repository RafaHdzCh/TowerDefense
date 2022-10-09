using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lives;

    void Update()
    {
        lives.text = PlayerStats.Lives.ToString();
    }
}
