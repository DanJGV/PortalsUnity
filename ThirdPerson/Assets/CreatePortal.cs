using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CreatePortal : MonoBehaviour
{

    public GameObject portalA;
    public GameObject portalB;
    public Camera aimCam;
    public GameObject player;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && player.GetComponent<PlayerController>().aiming)
        {
            ShootPortal(portalA);
        }

        if(Input.GetMouseButtonDown(1) && player.GetComponent<PlayerController>().aiming)
        {
            ShootPortal(portalB);
        }
    }



    void ShootPortal(GameObject portal)
    {
        Debug.DrawRay(firePoint.transform.position, transform.forward * 100, Color.red, 2f);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;
        if(Physics.Raycast(aimCam.transform.position,aimCam.transform.forward, out hitInfo))
        {
            
            Quaternion findNormal = Quaternion.LookRotation(-hitInfo.normal);


            portal.transform.position = hitInfo.point;
            portal.transform.rotation = findNormal;
        }
    }
}
