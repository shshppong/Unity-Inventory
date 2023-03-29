using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("������Ʈ")]
    [SerializeField] RectTransform _itemSlotHandler;
    [SerializeField] GameObject _itemSlotPrefab;

    [Header("Item Slot ��")]
    [SerializeField] int slotCount = 25; // 25���� ���� ����
    [SerializeField] float slotSize = 80f; // ���� ũ��
    [SerializeField] float padding = 10f; // ���� �� ����

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        //for (int i = 0; i < slotCount; i++)
        //{
        //    GameObject slot = Instantiate(_itemSlotPrefab, transform);
        //    slot.transform.SetParent(__itemSlotHandler);
        //    RectTransform slotTransform = slot.GetComponent<RectTransform>();

        //    // ���� ũ��� ��ġ ����
        //    slotTransform.sizeDelta = new Vector2(slotSize, slotSize);
        //    slotTransform.localPosition = new Vector3(i % 5 * (slotSize + padding), -Mathf.Floor(i / 5) * (slotSize + padding), 0f);
        //}
        CreateSlots();
    }

    private void CreateSlots()
    {
        // �г��� ũ�⸦ �����´�.
        float panelWidth = _itemSlotHandler.rect.width;
        float panelHeight = _itemSlotHandler.rect.height;

        // ������ ������ ���� �г� ���ο� ��ġ�� �� �ִ� ����/���� �ִ� ���� ������ ����Ѵ�.
        int maxHorizontalSlots = Mathf.FloorToInt(panelWidth / (_itemSlotPrefab.GetComponent<RectTransform>().rect.width + padding));
        int maxVerticalSlots = Mathf.FloorToInt(panelHeight / (_itemSlotPrefab.GetComponent<RectTransform>().rect.height + padding));

        // ������ �ڵ����� �����Ѵ�.
        int rowCount = Mathf.CeilToInt((float)slotCount / maxHorizontalSlots);
        float startX = -((maxHorizontalSlots - 1) * (_itemSlotPrefab.GetComponent<RectTransform>().rect.width + padding) / 2f);
        float startY = ((rowCount - 1) * (_itemSlotPrefab.GetComponent<RectTransform>().rect.height + padding) / 2f);

        for (int i = 0; i < slotCount; i++)
        {
            GameObject slotObject = Instantiate(_itemSlotPrefab, _itemSlotHandler);
            RectTransform slotTransform = slotObject.GetComponent<RectTransform>();

            int row = i / maxHorizontalSlots;
            int column = i % maxHorizontalSlots;

            slotTransform.anchoredPosition = new Vector2(startX + column * (_itemSlotPrefab.GetComponent<RectTransform>().rect.width + padding),
                                                         startY - row * (_itemSlotPrefab.GetComponent<RectTransform>().rect.height + padding));
        }
    }
}
