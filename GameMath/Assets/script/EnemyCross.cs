
using UnityEngine;

public class EnemyCross : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 dirToTarget = (target.position - forward).normalized;

        Vector3 crossProduct = CrossProduct(forward, dirToTarget);

        if(crossProduct.y > 0.1f)
        {
            Debug.Log("���� �����ʿ� �ֽ��ϴ�");
        }
        else if (crossProduct.y < -0.1f)
        {
            Debug.Log("���� ���ʿ� �ֽ��ϴ�");
        }
    }

    Vector3 CrossProduct(Vector3 A, Vector3 B)
    {
        
            return new Vector3(
                A.y * B.z - A.z*B.y,
                A.z * B.x - A.x*B.z,
                A.x * B.y - A.y*B.x
            );
    }
}
