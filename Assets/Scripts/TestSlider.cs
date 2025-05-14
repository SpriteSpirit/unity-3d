using UnityEngine;
using UnityEngine.UI;

public class TestSlider : MonoBehaviour
{
    public Slider slider;
    private float sliderValue = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = 100f;
        slider.minValue = 0f;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= sliderValue * Time.deltaTime;
    }
}
