using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float orthographicsSize;
    private float targetOrthographicsSize;

    void Start()
    {
        orthographicsSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicsSize = orthographicsSize;
    }

    private void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y).normalized;
        float moveSpeed = 30f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

    }

    private void HandleZoom()
    {
        float zoomAmount = 2f;
        targetOrthographicsSize += -Input.mouseScrollDelta.y * zoomAmount;

        float minOrthographicSize = 10;
        float maxOrthographicSize = 30;
        targetOrthographicsSize = Mathf.Clamp(targetOrthographicsSize, minOrthographicSize, maxOrthographicSize);

        float zoomSpeed = 5f;
        orthographicsSize = Mathf.Lerp(orthographicsSize, targetOrthographicsSize, Time.deltaTime * zoomSpeed);

        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicsSize;
    }



}
