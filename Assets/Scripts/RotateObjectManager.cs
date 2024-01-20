using System.Collections;
using UnityEngine;

/// <summary>
/// Вращение объекта и / или камеры с помощью мыши.
/// </summary>
public class MouseRotateObject : MonoBehaviour
{
    [Header("Скорость вращения объекта\n")]
    [SerializeField] private float rotationSpeed = 5f;

    [Header("Объект, который будет вращаться по горизонтали\n")]
    [Tooltip("Если вращается только cameraContainerObject, поле targetObject можно оставить пустым \n")]
    [SerializeField] private GameObject targetObject;

    [Header("Контейнер камеры, который будет вращаться по вертикали\n")]
    [Tooltip("Если вращается только targetObject, поле cameraContainerObject можно оставить пустым \n")]
    [SerializeField] private GameObject cameraContainerObject;

    private bool isRotating = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Начинаем вращение при нажатии левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
            StartCoroutine(RotateObjects());
        }
        // Прекращаем вращение при отпускании левой кнопки мыши
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
    }

    IEnumerator RotateObjects()
    {
        while (isRotating) {
            float mouseXDelta = Input.mousePosition.x - lastMousePosition.x;
            float mouseYDelta = Input.mousePosition.y - lastMousePosition.y;
            // Вращаем targetObject по горизонтали, если он задан
            if (targetObject != null) {
                targetObject.transform.Rotate(Vector3.up, -mouseXDelta * rotationSpeed * Time.deltaTime);
            }
            // Вращаем cameraContainerObject по вертикали, если он задан
            if (cameraContainerObject != null) {
                cameraContainerObject.transform.Rotate(Vector3.right, -mouseYDelta * rotationSpeed * Time.deltaTime);
            }
            // Сохраняем текущее положение мыши для следующего кадра
            lastMousePosition = Input.mousePosition;
            yield return null;
        }
    }
}
