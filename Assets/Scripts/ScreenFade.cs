using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;
    private Coroutine fadeCoroutine;

    public void FadeToBlack()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeImage(1f)); // Fade to black
    }

    public void FadeToClear()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeImage(0f)); // Fade to clear
    }

    private IEnumerator FadeImage(float targetAlpha)
    {
        Color color = fadeImage.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * fadeSpeed;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime);
            fadeImage.color = color;
            yield return null;
        }

        color.a = targetAlpha;
        fadeImage.color = color;
    }
}
