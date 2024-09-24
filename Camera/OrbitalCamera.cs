using UnityEngine;
using UnityEngine.EventSystems;

public class OrbitCamera : MonoBehaviour
{
    public Transform target; // Цель, вокруг которой будет вращаться камера
    public float swipeSensitivity = 0.1f; // Чувствительность вращения
    public float soft=10;
    public float distance = 5.0f; // Расстояние от камеры до цели
    public float minYAngle = -20f; // Минимальный угол по оси Y
    public float maxYAngle = 80f; // Максимальный угол по оси Y

    //private Vector2 lastTouchPosition;
    private Vector3 currentRotation;
    private bool isDragging;


    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target is not assigned. Please assign a target in the inspector.");
            return;
        }

        // Установка начальной позиции камеры
        currentRotation = transform.eulerAngles;
        UpdateCameraPosition();
    }

    void Update()
    {
        if (target)
        {
            //gameOverWindow.Close();
            UpdateCameraPosition();
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                bool canContinue = false;
                foreach (Touch t in Input.touches)
                {
                    if (EventSystem.current.IsPointerOverGameObject(t.fingerId))
                        continue;
                    else
                    {
                        canContinue = true;
                        touch = t; break;

                    }
                }
                if (!canContinue) return;

                if (touch.phase == TouchPhase.Began)
                {
                    //lastTouchPosition = touch.position;
                    isDragging = true;
                }
                else if (touch.phase == TouchPhase.Moved && isDragging)
                {
                    Vector2 delta = touch.deltaPosition * swipeSensitivity;
                    currentRotation.x -= delta.y;
                    currentRotation.y += delta.x;
                    currentRotation.x = Mathf.Clamp(currentRotation.x, minYAngle, maxYAngle);

                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isDragging = false;
                }
            }

        }
        else
        {
            //gameOverWindow.Open();
        }

    }

    void UpdateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime*soft);
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * soft);
    }
}
