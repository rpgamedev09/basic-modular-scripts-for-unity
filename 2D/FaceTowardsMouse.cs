using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTowardsMouse : MonoBehaviour
{
    private Camera cam;
    
    [SerializeField,Range(1,100)] private float rotationSpeed = 10;

    [SerializeField] private Vector2 xClamp;
    [SerializeField] private Vector2 yClamp;

    private bool shouldClamp = false;
    

    void Awake()
    {
        cam = Camera.main;
    }

   
    private void Update()
    {
        moveTurret();
    }
        
    void moveTurret()
    {
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (shouldClamp)
        {
            mousePosition = new Vector2(Mathf.Clamp(mousePosition.x, xClamp.x, xClamp.y), Mathf.Clamp(mousePosition.y, yClamp.x, yClamp.y));
        }
        mousePosition.z = 0;

        //transform.up = mousePosition;
        transform.up = Vector3.MoveTowards(transform.up, mousePosition, rotationSpeed * Time.deltaTime);

    }
}
