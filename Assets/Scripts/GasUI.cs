using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GasUI : MonoBehaviour
{
    Image _gasLevel;

    void Start()
    {
        _gasLevel = transform.GetComponent<Image>();
    }

    void Update()
    {
        _gasLevel.fillAmount = CarController.fuel/100;
    }
}
