using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreRaycast : MonoBehaviour
{
    public Camera camera;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 1));
        
        if (Physics.Raycast(ray, out hit)) {
            //Transform objectHit = hit.transform;
            
            arrow.transform.SetPositionAndRotation(hit.point, Quaternion.LookRotation(hit.normal));
            // Do something with the object that was hit by the raycast.
        }
    }
}
