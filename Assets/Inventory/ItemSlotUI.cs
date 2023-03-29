using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("������Ʈ")]
    [SerializeField] Image _iconImage;
    [SerializeField] TextMeshProUGUI _amountText;
    [SerializeField] Image _highlightImage;

    [Header("��")]
    [Range(1.0f, 4.0f)]
    [SerializeField] float _fadeSpeed;
    [SerializeField] float _targetAlpha;

    #region ���̵� �ִϸ��̼�
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
