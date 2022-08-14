using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Size;

    [Header("Sensi")]
    public float MouseWheelSensi;

    [Header("Debug")]
    public float MouseWheel;
    public Vector2 MousePos;
    public Vector2 MouseStartPos;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // サイズ変更
        MouseWheel = Input.GetAxis("Mouse ScrollWheel") * MouseWheelSensi * -1;
        Size *= 1 + MouseWheel;
        Camera.main.orthographicSize = Size;

        // サイズ変更をもとに移動
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Camera.main.transform.position = Vector3.Lerp(MousePos, Camera.main.transform.position, 1 + MouseWheel);
        SetCameraZ();

        // 左クリックで移動
        if (Input.GetMouseButtonDown(0))
        {
            MouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            transform.position += (Vector3)MouseStartPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetCameraZ();
        }
        if (Input.GetMouseButtonUp(0))
        {
            
        }
    }

    public void SetCameraZ()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);
    }
}
