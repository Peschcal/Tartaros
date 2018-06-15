using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    public GameObject wall;
    public GameObject player;

    private float standardOffset ;
    public float maxOffset;

    public float cameraAdjustmentSpeed;

    private void Start()
    {
        standardOffset = -5;
        
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, wall.transform.position) < 5)
        {

            // if(offset.z > maxOffset)
            // offset.z =  (Vector3.Distance(player.transform.position, wall.transform.position)) -5 ;
            offset.z = maxOffset;
        }
        else
        {
            //if(offset.z < standardOffset)
            //{
            //    offset.z += Time.deltaTime *cameraAdjustmentSpeed;
            //}
            //if(offset.z - standardOffset > -4) {
            //    offset.z = standardOffset;
            //}
           offset.z = standardOffset;
        }
        transform.position = smoothedPosition;
    }
}
