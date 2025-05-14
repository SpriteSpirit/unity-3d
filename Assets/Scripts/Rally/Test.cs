using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{
    private float speed = 20f;
    private float rotationSpeed = 60f;
    private float sensitivity = 2f;

    private float verticalMinAngle = -45;
    private float verticalMaxAngle = 45;

    private float rotationX = 0f;


    private void Update()
    {
        // Перемещение вперед и назад, повороты влево-вправо
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, vertical);
        transform.Rotate(0, horizontal, 0);

        // Вращение камеры вверх и вниз
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, verticalMinAngle, verticalMaxAngle);

        // Применяем вращение только по оси X
        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);
    }
}
