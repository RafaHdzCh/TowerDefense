using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI roundsText;
    private readonly string initialRoundsCount = "0";
    private void OnEnable()
    {
        StartCoroutine(nameof(AnimateText));
    }

    IEnumerator AnimateText()
    {
        roundsText.text = initialRoundsCount;
        int round = 0;
        yield return new WaitForSeconds(.5f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(.05f);
        }
    }
}
