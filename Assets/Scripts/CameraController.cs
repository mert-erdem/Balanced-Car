using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 _targetPos, _smoothPos;
    [Range(0f,1f)] public float smoothnessRate = 0.9f;

    private void LateUpdate() => Follow();

    private void Follow()
    {
        _targetPos = new Vector3(player.position.x+4, transform.position.y, transform.position.z);
        _smoothPos = Vector3.Lerp(transform.position, _targetPos, smoothnessRate);

        transform.position = _smoothPos;
    }
}
