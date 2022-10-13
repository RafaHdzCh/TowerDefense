using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField] Image sceneFaderImage;
    [SerializeField] AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(nameof(FadeIn));
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;
        

        while(t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            sceneFaderImage.color = new Color(0f, 0f, 0f, a);
            yield return 0;         //Wait a frame
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;


        while (t < 0)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            sceneFaderImage.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
