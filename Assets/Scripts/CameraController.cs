using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [HideInInspector] public float zoomRate = 0f;

    [SerializeField] private float smoothness = 0.05f;
    [SerializeField] private Vector3 positionOffset;

    private Transform target;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void Start()
    {
        target = PlayerAgent.Instance.transform;
    }

    public void LateUpdate()
    {
        if (!target)
        {
            return;
        }

        Vector3 targetPosition = target.position;
        transform.position = SmoothPosition(targetPosition + positionOffset - (positionOffset * zoomRate));
    }

    private Vector3 smoothVelocity = Vector3.zero;
    private Vector3 SmoothPosition(Vector3 desiredPosition)
    {
        return Vector3.SmoothDamp(transform.position, desiredPosition, ref smoothVelocity, smoothness * Time.deltaTime);
    }
}
