using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAssistant : MonoBehaviour
{
    [SerializeField] private GameStateHandler _gameStateHandler;
    [SerializeField] private TextMeshProUGUI _pressF;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _winView;

    private void OnEnable()
    {
        _gameStateHandler.OnPlayerFinished += ShowPressF;
        _gameStateHandler.OnRoundCompleted += () => _winView.SetActive(true);
        UserInput.OnPressF += HidePressF;
        _gameStateHandler.OnGameOver += () => _restartButton.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _gameStateHandler.OnPlayerFinished -= ShowPressF;
        _gameStateHandler.OnRoundCompleted += () => _winView.gameObject.SetActive(false);
        UserInput.OnPressF -= HidePressF;
        _gameStateHandler.OnGameOver += () => _restartButton.gameObject.SetActive(false);
    }

    private void HidePressF()
    {
        if (_pressF.alpha != 0f)
            _pressF.alpha = 0f;
    }

    private void ShowPressF()
    {
        _pressF.rectTransform.position = Vector2.zero;
        _pressF.alpha = 255f;
    }
}
