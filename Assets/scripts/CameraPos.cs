using UnityEngine;

public class CameraPos : MonoBehaviour
{
    //Positions
    public Transform currentTarget;
    public Transform player;
    public Transform pos1;
    public Transform pos2;

    [Range (0f, 1.0f)]
    public float smoothSpeed = 0.1f;
    public Vector3 offset;

    void Start()
    {
        currentTarget = player;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentTarget = pos1;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentTarget = pos2;


        //Follow target
        Vector3 desiredPos = currentTarget.position + offset;
        Vector3 smoothedPos = Vector3.LerpUnclamped(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(currentTarget);
    }
}
