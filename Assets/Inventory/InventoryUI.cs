using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("오브젝트")]
    [SerializeField] RectTransform _itemSlotHandler;
    [SerializeField] GameObject _itemSlotPrefab;

    [Header("Item Slot 값")]
    [SerializeField] int slotCount = 25; // 25개의 슬롯 생성
    [SerializeField] float slotSize = 80f; // 슬롯 크기
    [SerializeField] float padding = 10f; // 슬롯 간 간격

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

        //    // 슬롯 크기와 위치 설정
        //    slotTransform.sizeDelta = new Vector2(slotSize, slotSize);
        //    slotTransform.localPosition = new Vector3(i % 5 * (slotSize + padding), -Mathf.Floor(i / 5) * (slotSize + padding), 0f);
        //}
        CreateSlots();
    }

    private void CreateSlots()
    {
        // 패널의 크기를 가져온다.
        float panelWidth = _itemSlotHandler.rect.width;
        float panelHeight = _itemSlotHandler.rect.height;

        // 슬롯의 갯수에 따라 패널 내부에 배치할 수 있는 가로/세로 최대 슬롯 갯수를 계산한다.
        int maxHorizontalSlots = Mathf.FloorToInt(panelWidth / (_itemSlotPrefab.GetComponent<RectTransform>().rect.width + padding));
        int maxVerticalSlots = Mathf.FloorToInt(panelHeight / (_itemSlotPrefab.GetComponent<RectTransform>().rect.height + padding));

        // 슬롯을 자동으로 정렬한다.
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
