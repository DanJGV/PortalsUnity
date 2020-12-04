using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 1;

    public float xAxisClamp = 0;

    [SerializeField]
    Transform pivotVertical;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().aiming)
        {
            //float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            float rotAmountY = y * rotSpeed;
            xAxisClamp += rotAmountY;
            //transform.Rotate(new Vector3(0, x * rotSpeed, 0));

            Vector3 rotPlayerArm = pivotVertical.transform.rotation.eulerAngles;

            rotPlayerArm.x += rotAmountY;

            /*pivotVertical.Rotate(new Vector3(rotAmountY, 0, 0));
            if(pivotVertical.rotation.eulerAngles.x < -90 || pivotVertical.rotation.eulerAngles.x > 90)
            {
                rotAmountY -= y;
            }*/

            pivotVertical.rotation = Quaternion.Euler(rotPlayerArm);

            Mathf.Clamp(rotPlayerArm.x, 70, -70);
            if (xAxisClamp < -90)
            {
                xAxisClamp = -90;
                rotPlayerArm.x = -90;
            }
            else if (xAxisClamp > 90)
            {
                xAxisClamp = 90;
                rotPlayerArm.x = 90;
            }

        }
    }
}
