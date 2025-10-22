using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public float CameraSpeed;
    
    private Transform Pt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Pt = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = Vector3.Lerp(transform.position, Pt.position, CameraSpeed * Time.deltaTime);
        transform.position = new  Vector3(desiredPosition.x, desiredPosition.y, transform.position.z);
    }
}
