using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public Renderer playerRenderer;  // �÷��̾��� �������� �����մϴ�.
    [SerializeField] float blinkDuration = 1.0f;  // �����Ÿ��� �� �ð��� �����մϴ�.
    [SerializeField] float blinkInterval = 0.1f;  // �����Ÿ� ������ �����մϴ�.

    private void Start()
    {
        if (playerRenderer == null)
        {
            playerRenderer = GetComponent<Renderer>();
        }
    }

    public void StartBlinking()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        float endTime = Time.time + blinkDuration;

        while (Time.time < endTime)
        {
            playerRenderer.enabled = !playerRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }

        playerRenderer.enabled = true;  // �����Ÿ��� ������ �ٽ� �������� Ȱ��ȭ�մϴ�.
    }
}
