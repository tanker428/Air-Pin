using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOnlyCamera: MonoBehaviour
{
    // This Camera move only verticle.
    // So camera transform in player children.
    // このカメラは縦の視点移動のみです。利用する場合はこのクラスをアタッチするカメラをプレイヤーの子にしてください。

    private Vector3 angle;
    [SerializeField]
    private float sensitivityY;

    void Start()
    {

        angle = transform.eulerAngles;

        //Lock Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        angle = transform.eulerAngles;

        if (Input.GetKey(KeyCode.Backspace)) UnityEditor.EditorApplication.isPlaying = false;
        if (Input.GetKey(KeyCode.E))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        float vertical;

        vertical = Input.GetAxis("Mouse Y") * sensitivityY;

        angle.x -= vertical * Time.deltaTime;
        transform.eulerAngles = angle;
    }
}
