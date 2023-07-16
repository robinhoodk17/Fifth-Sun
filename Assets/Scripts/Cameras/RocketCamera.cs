using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCamera : MonoBehaviour
{
    [SerializeField] private GameObject rocket;
    [SerializeField] private GameObject cameraTarget;
    public Vector3 cameraOffset = new Vector3(0, .0283f, -.24f);
    [SerializeField] private float cameraResponsiveness = 20;
    private float rocketX;
    private float rocketY;
    private float rocketZ;
    // Update is called once per frame
    void FixedUpdate()
    {
        rocketX = rocket.transform.eulerAngles.x;
        rocketY = rocket.transform.eulerAngles.y;
        rocketZ = rocket.transform.eulerAngles.z;
        Quaternion targetQuaternion = Quaternion.Euler(new Vector3(rocketX - rocketX, rocketY, rocketZ-rocketZ));
        cameraTarget.transform.position = rocket.transform.position + cameraOffset;
        cameraTarget.transform.rotation = Quaternion.Lerp(cameraTarget.transform.rotation, targetQuaternion, Time.deltaTime*cameraResponsiveness);
    }

    private void FollowRocket()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, cameraTarget.transform.position, Time.deltaTime*cameraResponsiveness);
        gameObject.transform.LookAt(cameraTarget.transform.position);
    }
}
