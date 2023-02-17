using UnityEngine;

public class UiInput : MonoBehaviour
{
    [SerializeField] private UIButton[] _buttons;
    private Player _player;

    private void Start()
    {
        SubscribeButtons();
        SelectButton(_buttons[0]);

        _player = GameController.Instance.Player;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) _player.Shoot(_player.Gun);

        if (Input.GetKeyDown(KeyCode.Escape)) GameController.Instance.PauseTurnOn();

        if (Input.GetKeyDown(KeyCode.F)) ButtonAction();

        if (Input.GetKeyDown(KeyCode.W)) ButtonSelection();
    }

    private void SubscribeButtons()
    {
        foreach (var button in _buttons)
            button.OnSelected += SelectButton;
    }

    private void SelectButton(UIButton button)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i] == button) _buttons[i].IsSelected = true;
            else _buttons[i].IsSelected = false;
        }
    }

    private void ButtonAction()
    {
        foreach (var button in _buttons)
            if (button.IsSelected)
                button.OnClick.Invoke();
    }

    private void ButtonSelection()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i].IsSelected)
            {
                if (i == _buttons.Length - 1)
                {
                    _buttons[0].IsSelected = true;
                    SelectButton(_buttons[0]);
                    return;
                }
                else
                {
                    _buttons[i + 1].IsSelected = true;
                    SelectButton(_buttons[i + 1]);
                    return;
                }
            }
        }
        SelectButton(_buttons[0]);
    }
}

