using UnityEngine;

using UnityEngine;

public class AutoRotation1 : MonoBehaviour
{
    

    // y축을 기준으로 1초마다 45도 회전
    void Update()
    {
        transform.Rotate(0,30*Time.deltaTime,0);
    }
}
