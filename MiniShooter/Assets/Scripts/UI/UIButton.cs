using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[Serializable] public class MyEvent : UnityEvent { }

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Color normalColor;
    [SerializeField] private Color selectedColor;

    public MyEvent OnClick;

    public Action<UIButton> OnSelected;

    private Image image => GetComponent<Image>();

    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected == value) return;
            _isSelected = value;

            if (_isSelected) image.color = selectedColor;
            else image.color = normalColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsSelected = true;
        OnSelected.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData) => IsSelected = false;

    public void OnPointerClick(PointerEventData eventData) => OnClick.Invoke();
}