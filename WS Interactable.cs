using UnityEngine;
using UnityEngine.UI; // UI를 사용하기 위해 필요합니다.

public class WSInteraction : MonoBehaviour
{
    public GameObject interactionText; // UI 텍스트를 연결할 변수
    private bool isNearSubmarine = false; // 서브마린 근처 여부를 저장하는 변수

    void Start()
    {
        // 게임이 시작될 때 UI를 비활성화합니다.
        interactionText.SetActive(false);
    }

    void Update()
    {
        // 만약 서브마린 근처이고 F키가 눌렸다면 상호작용을 처리합니다.
        if (isNearSubmarine && Input.GetKeyDown(KeyCode.F))
        {
            InteractWithSubmarine();
        }
         // UI가 항상 카메라를 향하도록 설정
        if (isNearSubmarine)
        {
            interactionText.transform.LookAt(Camera.main.transform); // 카메라를 바라보게 함
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("submarine")) // 태그가 submarine인지 확인
        {
            isNearSubmarine = true; // 서브마린 근처로 상태 변경
            interactionText.SetActive(true); // UI를 활성화합니다.
            // UI 텍스트를 서브마린 오브젝트 위로 위치 조정
            interactionText.transform.position = other.transform.position + new Vector3(0, 2, 0); // 서브마린 위쪽에 위치
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("submarine")) // 태그가 submarine인지 확인
        {
            isNearSubmarine = false; // 서브마린 근처가 아님으로 상태 변경
            interactionText.SetActive(false); // UI를 비활성화합니다.
        }
    }

    private void InteractWithSubmarine()
    {
        // 상호작용 로직을 여기에 작성
        Debug.Log("서브마린과 상호작용했습니다!"); // 콘솔에 메시지를 출력합니다.
    }
}