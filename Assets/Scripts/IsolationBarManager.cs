using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsolationBarManager : MonoBehaviour
{
    public Slider isolationSlider;
    public float maxIsolation = 100f;
    public float currentIsolation;
    public float depletionRate = 1f;
    public float refillRate = 5f;

    private bool nearNPC = false;

    void Start()
    {
        currentIsolation = maxIsolation;
        isolationSlider.maxValue = maxIsolation;
        isolationSlider.value = currentIsolation;
    }

    void Update()
    {
        if (nearNPC)
        {
            RefillIsolation(refillRate * Time.deltaTime);
            FindObjectOfType<ScreenFade>().FadeToClear();
        }
        else
        {
            DecreaseIsolation(depletionRate * Time.deltaTime);
            if (currentIsolation <= 0)
            {
                currentIsolation = 0;
                isolationSlider.value = currentIsolation;
                FindObjectOfType<ScreenFade>().FadeToBlack();
            }
        }
    }

    public void DecreaseIsolation(float amount)
    {
        currentIsolation -= amount;
        isolationSlider.value = currentIsolation;
    }

    public void RefillIsolation(float amount)
    {
        currentIsolation = Mathf.Min(currentIsolation + amount, maxIsolation);
        isolationSlider.value = currentIsolation;
    }

    public void SetNearNPC(bool status)
    {
        nearNPC = status;
    }
}
