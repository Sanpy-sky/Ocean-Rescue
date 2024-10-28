using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 캐릭터의 Transform
    public float distance = 5.0f; // 카메라와 캐릭터 사이의 거리
    public float height = 2.0f; // 카메라의 높이
    public float rotationSpeed = 5.0f; // 회전 속도

    private float rotationY = 5.0f; // Y축 회전

    void Start()
    {
        // 마우스 커서를 숨기고 고정
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 마우스 이동 감지
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

        // Y축 회전 업데이트
        rotationY += mouseX;

        // 카메라 위치 계산
        Vector3 targetPosition = target.position + Vector3.up * height; // 캐릭터 위에 위치
        Quaternion rotation = Quaternion.Euler(0, rotationY, 0);

        // 카메라 위치 설정
        transform.position = targetPosition - rotation * Vector3.forward * distance;
        transform.LookAt(targetPosition); // 캐릭터를 바라보도록 설정
    }
}