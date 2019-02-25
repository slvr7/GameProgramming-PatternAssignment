using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAdjust : MonoBehaviour
{
    public float sensitivity = 10;
    public GameObject mainCamera;
    public float minY = 60;
    public float maxY = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        adjustView();
    }

    void adjustView()
    {
       // if (mainCamera.transform.position.y >= minY && mainCamera.transform.position.y <= maxY)
        {
            float f = Input.GetAxis("Mouse ScrollWheel") * sensitivity * Time.deltaTime;
            mainCamera.transform.Translate(0, f, 0, Space.World);
        }
    }
}
