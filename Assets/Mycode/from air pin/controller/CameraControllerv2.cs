using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerv2 : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 offset;
    private Vector3 setPosition;

    private Vector3 angle;
    //Radians
    private float deg = 0;

    //Radius
    private float r = 5;

    [SerializeField]//Height adjustment
    public float height;
    Transform rootTransform;
    float beforeY;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Camera Position Setting
        offset = transform.position - player.transform.position;
        offset.y += height;
        setPosition = player.transform.position += offset;
        transform.position = setPosition;

        //Initialize Look Position
        transform.LookAt(player.transform.position);
        angle = transform.eulerAngles;

        rootTransform = player.transform.root;
        beforeY = rootTransform.eulerAngles.y;

        //Lock Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //End Play
        if (Input.GetKey(KeyCode.Escape)) UnityEditor.EditorApplication.isPlaying = false;

        float horizontal;
        float vertical;
        float rootY = rootTransform.eulerAngles.y - beforeY;

        horizontal = Input.GetAxis("Mouse X") * 0.3f;
        vertical = Input.GetAxis("Mouse Y") * 0.1f;

        if (beforeY > rootY) deg -= rootY;
        if (beforeY < rootY) deg += rootY;

        if (0 < Input.mousePosition.x) deg += horizontal;

        if (0 > Input.mousePosition.x) deg -= horizontal;

        if (0 < Input.mousePosition.y) angle.x += vertical;

        if (0 > Input.mousePosition.y) angle.x -= vertical;

        //Position Calculation X
        setPosition.x = player.transform.position.x + r * Mathf.Cos(Mathf.Deg2Rad * deg);
        setPosition.y = player.transform.position.y + offset.y;
        setPosition.z = player.transform.position.z + r * Mathf.Sin(Mathf.Deg2Rad * deg);

        //Position Change
        transform.position = setPosition;

        beforeY = rootTransform.eulerAngles.y;
        //LookAt playerTransform + angleY
        transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + angle.x, player.transform.position.z));

    }
}
