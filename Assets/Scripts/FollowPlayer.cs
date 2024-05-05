using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowPlayer : MonoBehaviour
{
    private float rotationX = 0f;
    private float rotationY = -12f;
    private float minimumX = -45f;
    private float maximumX = 45f;
    public Vector3 screenPosition;
    public Transform playerpos;
    public Vector2 sensitivity = Vector2.one * 250f;

    void Start()
    {

    }


    void LateUpdate()
    {
        screenPosition = Input.mousePosition;
        transform.position = new Vector3(playerpos.position.x, playerpos.position.y + 0.5f, playerpos.transform.position.z);
        rotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity.y;
        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity.x;
        transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);// moves camera with mouse
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
    }
}
