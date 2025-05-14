
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    private float sensitivity = 100f;
    public float verticalRange = 90f;

    private Quaternion gunRotation;
    private float verticalAngle = 45f;  // ��������� ����

    private Camera _camera;
    public Transform _spawnPoint;
    private Quaternion camera_rotation;


    [Header("Crosshair")]
    public bool isZoom = false;

    private void Start()
    {
        Quaternion old_camera_rotation = camera_rotation;
        Input.ResetInputAxes();
        Cursor.lockState = CursorLockMode.Locked;   // �������� ������ � ������ ������.
        Cursor.visible = false;                     // �������� ������.

        gunRotation = Quaternion.identity;          // ������������� �������� ����� �� ���������.
        transform.localRotation = gunRotation;      // ��������� ��������� ��������.

        
        transform.position = new Vector3(-115.569f, 14.0220003f, 159.243057f);

        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        camera_rotation = new Quaternion(0f, 0.707106829f, 0, 0.707106829f);
        //_spawnPoint = GetComponent<BulletSpawner>().spawn;
    }

    private void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.visible = false;                 // ��������� ��� ������ �������.
            Cursor.lockState = CursorLockMode.Locked; // �������� ��������� ������.
        }

        if (Input.GetMouseButton(1))
        {
            isZoom = true;
            Quaternion rotation = Quaternion.LookRotation(_spawnPoint.forward);
            Vector3 eulerRotation = rotation.eulerAngles;
            eulerRotation.x += 5f; // ������������� �������� ��� �������� 
            rotation = Quaternion.Euler(eulerRotation);
            _camera.transform.rotation = rotation;
        }
        else
        {
            isZoom = false;
            camera_rotation = new Quaternion(0f, 0, 0, 0);

            // �������� �������� ����
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            // ��������� �������������� �������� ���� � �������� ����
            float newRotationY = transform.localEulerAngles.y + mouseX;

            // ��������� ������������ �������� ���� � �������� ����, � ������ �����������
            verticalAngle -= mouseY;
            verticalAngle = Mathf.Clamp(verticalAngle, -verticalRange, verticalRange);

            // ��������� ����������� �� ��� Y
            if (newRotationY > 180f)
            {
                newRotationY -= 360f;
            }

            // ��������� ����������� �� ��� Y
            newRotationY = Mathf.Clamp(newRotationY, -45f, 45f);

            // ��������� ��������
            transform.localEulerAngles = new Vector3(0f, newRotationY, verticalAngle);

            // ����� ������
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        if (isZoom)
        {
            _camera.fieldOfView = 20;
        }
        else
        {
            _camera.fieldOfView = 60;
        }
    }
}

/*private float horizontal;
    private float vertical;
    private float sensitivity = 2f;

    void Start()
    {
        
    }

 
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        horizontal = Input.GetAxis("Mouse X") * sensitivity;
        vertical = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(0, horizontal, 0);
        transform.Rotate(0, 0, vertical);
    }
 
 */

/*
  // �������� �������� ����
 float horizontal = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
 float vertical = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

 // ��������� �������� ���� � �������� ����
 verticalAngle += vertical;
 verticalAngle = Mathf.Clamp(verticalAngle, -verticalRange, verticalRange); // ����������� ����� � �������� ���������

 // �������� �����
 // �������� (Y)
 gunRotation *= Quaternion.Euler(0f, horizontal, 0f);
 // �������� (�) � �������������
 gunRotation = Quaternion.Euler(verticalAngle, gunRotation.eulerAngles.y, 0f);

 // ��������� �������� - ��� ��������� �� ������ �����
 transform.localRotation = gunRotation;
 */
