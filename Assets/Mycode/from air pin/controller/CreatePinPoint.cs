using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class CreatePinPoint: MonoBehaviour
{
    [SerializeField]
    private float distance = 100.0f;
    [SerializeField]
    private GameObject Pinpoint;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                Instantiate(Pinpoint, hit.point, Quaternion.identity);
            }
        }
    }
}
