using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class EnemyMovemont : MonoBehaviour
{
    public Transform player;
    public float viewDistance = 10f;
    public float viewAngle = 60f;
    public Transform target;

    public float dashSpeed = 10f;
    public float parryCheckDistance = 1.5f;

    private bool isChasing = false;
    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        if (!isChasing)
        {
            DetectPlayer();
        }
        else
        {
            DashToPlayer();
        }
    }

    void DetectPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= viewDistance)
        {
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            if (angle <= viewAngle * 0.5f)
            {
                isChasing = true;
            }
        }
    }

    void DashToPlayer()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            dashSpeed * Time.deltaTime
        );

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= parryCheckDistance)
        {
            CheckParry();
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
    void CheckParry()
    {
        test pc = player.GetComponent<test>();
        Vector3 forward = transform.forward;
        Vector3 dirToTarget = (target.position - forward).normalized;

        Vector3 crossProduct = CrossProduct(forward, dirToTarget);


        bool isEnemyOnRight = crossProduct.y > 0.1f;
        bool isEnemyOnLeft = crossProduct.y < 0.1f;

        // 🔥 패링 입력 체크
        if (isEnemyOnLeft && Input.GetKeyDown(KeyCode.Q))
        {
            ParrySuccess("왼쪽 패링 성공 (Q)");
        }
        else if (isEnemyOnRight && Input.GetKeyDown(KeyCode.E))
        {
            ParrySuccess("오른쪽 패링 성공 (E)");
        }
        else
        {
            ParryFail();
        }
    }

    void ParrySuccess(string message)
    {
        Debug.Log(message);
        isDead = true;
        Destroy(gameObject);
    }

    void ParryFail()
    {
        Debug.Log("패링 실패! 씬 리셋");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}