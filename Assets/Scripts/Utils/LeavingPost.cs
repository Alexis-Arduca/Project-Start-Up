using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LeavingPost : MonoBehaviour
{
    private GameObject blackPanel;
    private Image panelImage;
    private bool isFading = false;
    public TypewriterEffect typewriterEffect;
    public string messageToShow;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");

        if (canvas != null)
        {
            Transform panelTransform = canvas.transform.Find("BlackPanel");

            if (panelTransform != null)
            {
                blackPanel = panelTransform.gameObject;
                panelImage = blackPanel.GetComponent<Image>();

                if (panelImage != null)
                {
                    Color initialColor = panelImage.color;
                    initialColor.a = 0f;
                    panelImage.color = initialColor;
                    blackPanel.SetActive(true);
                }
            }
        }
    }

    public void StartFadeOut(float fadeDuration)
    {
        if (!isFading && panelImage != null)
        {
            StartCoroutine(FadeToBlack(fadeDuration));
        }
    }

    private IEnumerator FadeToBlack(float duration)
    {
        isFading = true;
        float elapsedTime = 0f;
        Color panelColor = panelImage.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration);
            panelColor.a = alpha;
            panelImage.color = panelColor;
            yield return null;
        }

        panelColor.a = 1f;
        panelImage.color = panelColor;
        isFading = false;

        if (typewriterEffect != null)
        {
            typewriterEffect.StartText(messageToShow);
        }
    }
}
