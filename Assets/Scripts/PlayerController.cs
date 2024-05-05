using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
   // public bool isShiftPressed = false;
    static public float speedforward = 10f;
    public float speedSides = 10f;

    public Vector2 sensitivity = Vector2.one * 360f;

   // public GameObject ShieldEffect;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");//move forward and backwards
        transform.Translate(Vector3.forward * speedforward * verticalInput * Time.deltaTime);

        float horizontalInput = Input.GetAxis("Horizontal");//move left and right
        transform.Translate(Vector3.right * speedSides * horizontalInput * Time.deltaTime);

    }

    void LateUpdate()
    {
        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity.x;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);// player camera with mouse
    }
}
