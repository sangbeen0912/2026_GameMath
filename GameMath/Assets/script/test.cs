using UnityEngine;
using UnityEngine.InputSystem;


public class test : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 mouseScreenPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isSprinting = false;


    public void OnPoint(InputValue value)
    {
     
      mouseScreenPosition = value.Get<Vector2>(); //마우스 위치 업데이트
    }
        
    public void OnSprint(InputValue value)
    {
         isSprinting = value.isPressed; // 버튼을 누르고 있으면 O 떄면 X

    }

    public void OnClick(InputValue value)
    {
        if ( value.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
            RaycastHit[] hits = Physics.RaycastAll(ray); //레이저 경로에 있는 모든 물체를 탐색

            foreach (RaycastHit hit in hits )//모든 물체에 한에 반복
            {
                if (hit.collider.gameObject != gameObject) //부딫힌 물체가 나 자신이 아닐떄만
                {


                  targetPosition = hit.point;  //plane에 부딫힌 지점을 타겟
                  targetPosition.y = transform.position.y;
                  isMoving = true;

                  break; //탐색 했으니foreach 반복 중단
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
       if (isMoving)
       {
            Vector3 A = targetPosition - transform.position;

            transform.position += A * moveSpeed * Time.deltaTime;

            if ( A.magnitude <= 0.1)
            {
                isMoving = false;
            }
       }
    }
}
