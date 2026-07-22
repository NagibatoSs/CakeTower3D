using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class CountdownUIHandler: MonoBehaviour
{
    [SerializeField] CountdownBlockController countdown;

    [SerializeField] TMP_Text timerText;
    [SerializeField] CanvasGroup countdownGroup;
    [SerializeField] [Range(0.05f, 1f)] float animationDuration = 0.25f;
    [SerializeField] private float startScale = 0.5f;
    [SerializeField] private float endScale = 1.2f;
    private Transform textTransform;

    private void Awake()
    {
        textTransform = timerText.transform;
    }

    private void OnEnable()
    {
        countdown.OnCountdownChanged += ChangeUI;
        countdown.OnCountdownFinished += Hide;
        countdown.OnCountdownStarted += StartCountdown;
    }

    private void OnDisable()
    {
        countdown.OnCountdownChanged -= ChangeUI;
        countdown.OnCountdownFinished -= Hide;
        countdown.OnCountdownStarted -= StartCountdown;
    }

    private void StartCountdown()
    {
        timerText.text = "";
        timerText.transform.localScale = Vector3.one;

        Show();
    }
    private void ChangeUI(string value)
    {
        timerText.text = value;
        StartCoroutine(PopAnimation());
    }

    IEnumerator PopAnimation()
    {
        float t = 0;
        textTransform.localScale = Vector3.one * startScale;

        while (t < animationDuration)
        {
            t += Time.deltaTime;

            float cubic = Mathf.Sin(t / animationDuration * Mathf.PI * 0.5f);

            textTransform.localScale = Vector3.Lerp(Vector3.one * startScale, Vector3.one * endScale, cubic);

            yield return null;
        }
    }

    private void Show()
    {
        countdownGroup.alpha = 1;
        countdownGroup.blocksRaycasts = true;
    }

    private void Hide()
    {
        countdownGroup.alpha = 0;
        countdownGroup.blocksRaycasts = false;
    }
}
