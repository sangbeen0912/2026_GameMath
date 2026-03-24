using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    public float rotaionSpeed = 100f;
    private Vector2 moveinput;
    public void OnMove(InputValue value)
    {
        moveinput = value.Get<Vector2>();
    }
    

    void Update()
    {
        
        Quaternion rotation = Quaternion.Euler(0f,moveinput.x * rotaionSpeed * Time.deltaTime, 0f);
        transform.rotation= rotation* transform.rotation;
    }
}
