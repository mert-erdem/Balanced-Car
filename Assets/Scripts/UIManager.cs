using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _gasLevel;
    [SerializeField] private TextMeshProUGUI textGameOver;

    private void Awake() => Driver.actionGameOver += ShowGameOverText;

    void Update() => GasUIUpdate();

    private void GasUIUpdate() => _gasLevel.fillAmount = CarController.fuel / 100;

    private void ShowGameOverText() => textGameOver.enabled = true;
}
