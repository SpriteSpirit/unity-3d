using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Vector3[] positions; // Ожидаем, что positions содержит минимум две позиции: верхнюю и нижнюю
    public float speed = 2f;
    private int index = 1; // Начинаем движение к позиции под индексом 1
    private float initialX; // Исходная позиция по X
    private float initialZ; // Исходная позиция по Z

    void Start()
    {
        if (positions.Length < 2)
        {
            Debug.LogError("Необходимо задать как минимум две позиции в массиве positions.");
            return;
        }
        transform.position = positions[0]; // Устанавливаем начальную позицию

        // Сохранение исходных X и Z координат
        initialX = transform.position.x;
        initialZ = transform.position.z;

        transform.position = new Vector3(initialX, positions[0].y, initialZ);
    }

    void Update()
    {
        // Получение целевого значения Y
        float targetY = positions[index].y;

        // Текущее значение Y
        float currentY = transform.position.y;

        // Вычисление нового значения Y с использованием MoveTowards для плавности
        float newY = Mathf.MoveTowards(currentY, targetY, speed * Time.deltaTime);

        // Установка новой позиции с фиксированными X и Z, и измененным Y
        transform.position = new Vector3(initialX, newY, initialZ);

        // Проверка, достигнута ли целевая позиция Y
        if (Mathf.Approximately(newY, targetY))
        {
            // Переключение на следующую целевую позицию
            index = (index == 0) ? 1 : 0;
        }
    }
}
