using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform camHolderTransform;
    [SerializeField] private float camPitchMin;
    [SerializeField] private float camPitchMax;

    [SerializeField] private float sensitivityX;
    [SerializeField] private float sensitivityY;

    private float xRot = 0;
    private float yRot = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        xRot = Mathf.Clamp(xRot - Input.GetAxis("Mouse Y") * sensitivityY, camPitchMin, camPitchMax);
        yRot = (yRot + Input.GetAxis("Mouse X") * sensitivityX) % 360f;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, yRot, 0);
        camHolderTransform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }

    public void SetSensitivities(float x, float y)
    {
        sensitivityX = x;
        sensitivityY = y;
    }
}