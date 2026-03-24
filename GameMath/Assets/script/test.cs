using UnityEngine;
using UnityEngine.InputSystem;


public class test : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 mouseScreenPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isSprinting = false;
     private bool isLeftParry = false;
     private bool isRightParry = false;



    public void OnPoint(InputValue value)
    {
     
      mouseScreenPosition = value.Get<Vector2>(); //���콺 ��ġ ������Ʈ
    }
        
    public void OnSprint(InputValue value)
    {
         isSprinting = value.isPressed; // ��ư�� ������ ������ O ���� X

    }

    public void OnLeftParry(InputValue value)
    {
         isLeftParry = value.isPressed; // ��ư�� ������ ������ O ���� X

    }

    public void OnRightParry(InputValue value)
    {
         isRightParry = value.isPressed; // ��ư�� ������ ������ O ���� X

    }

    public void OnClick(InputValue value)
    {
        if ( value.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
            RaycastHit[] hits = Physics.RaycastAll(ray); //������ ��ο� �ִ� ��� ��ü�� Ž��

            foreach (RaycastHit hit in hits )//��� ��ü�� �ѿ� �ݺ�
            {
                if (hit.collider.gameObject != gameObject) //�΋H�� ��ü�� �� �ڽ��� �ƴҋ���
                {


                  targetPosition = hit.point;  //plane�� �΋H�� ������ Ÿ��
                  targetPosition.y = transform.position.y;
                  isMoving = true;

                  break; //Ž�� ������foreach �ݺ� �ߴ�
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
