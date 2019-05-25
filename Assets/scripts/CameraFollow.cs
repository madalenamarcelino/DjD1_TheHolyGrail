using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Vector3 velocity;

    public float _smoothTimeX = 0;
    public float _smoothTimeY = 0;

    public GameObject player;
    public bool _bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void FixedUpdate()
    {
        float _posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, _smoothTimeX);
        float _posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, _smoothTimeY);

        transform.position = new Vector3(_posX, _posY, transform.position.z);

        if (_bounds)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }

    }

}