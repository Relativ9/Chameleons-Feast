using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    public float minDist = 1f;
    public float maxDist = 4f;
    public float smooth = 10f;
    public float distance;

    Vector3 dolDir;
    public Vector3 dolDirAdj;



    // Start is called before the first frame update
    void Awake()
    {
        dolDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;


    }


    private void LateUpdate()
    {
        Vector3 desiredCamPos = transform.parent.TransformPoint(dolDir * maxDist);

        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCamPos, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.8f), minDist, maxDist);

        }
        else
        {
            distance = maxDist;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dolDir * distance, Time.deltaTime * smooth);
    }


}
