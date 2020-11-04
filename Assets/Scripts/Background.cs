using UnityEngine;

/// <summary>
/// Contains all the methods for background movement
/// </summary>
public class Background : MonoBehaviour
{
    public float scrollSpeed;

    public float tileSizeZ;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        var newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);

        transform.position = _startPosition + Vector3.left * newPosition;
    }
}