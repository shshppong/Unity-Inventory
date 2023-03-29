using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("오브젝트")]
    [SerializeField] Image _iconImage;
    [SerializeField] TextMeshProUGUI _amountText;
    [SerializeField] Image _highlightImage;

    [Header("값")]
    [Range(1.0f, 4.0f)]
    [SerializeField] float _fadeSpeed;
    [SerializeField] float _targetAlpha;

    #region 페이드 애니메이션
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(EnableHighlight());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(DisableHighlight());
    }

    IEnumerator EnableHighlight()
    {
        _highlightImage.gameObject.SetActive(true);
        float fadeCount = 0;
        while (fadeCount < _targetAlpha)
        {
            fadeCount += _fadeSpeed * Time.deltaTime;
            if (fadeCount > 1.0f) break;
            _highlightImage.color = new Color(255, 255, 255, fadeCount);
            yield return null;
        }
    }
    IEnumerator DisableHighlight()
    {
        _highlightImage.gameObject.SetActive(true);
        float fadeCount = _targetAlpha;
        while (fadeCount > 0f)
        {
            fadeCount -= _fadeSpeed * Time.deltaTime;
            if (fadeCount < 0f) break;
            _highlightImage.color = new Color(255, 255, 255, fadeCount);
            yield return null;
        }
        _highlightImage.gameObject.SetActive(false);
    }
    #endregion
}
