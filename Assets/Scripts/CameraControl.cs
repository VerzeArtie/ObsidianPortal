using UnityEngine;
using System.Collections;

namespace ObsidianPortal
{
    public class CameraControl : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float moveX = 0.0f;
            float moveY = 0.0f;
            float moveZ = 0.0f;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveX += 0.0f;
                moveZ += 0.1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveX += 0.0f;
                moveZ += -0.1f;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveX += +0.1f;
                moveZ += 0.0f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveX += -0.1f;
                moveZ += 0.0f;
            }
            if (Input.GetKey(KeyCode.R))
            {
                moveY += +0.1f;
            }
            if (Input.GetKey(KeyCode.F))
            {
                if (this.transform.localPosition.y > 4.0f)
                {
                    moveY += -0.1f;
                }
            }


            this.transform.localPosition = new Vector3(this.transform.localPosition.x + moveX,
                                                       this.transform.localPosition.y + moveY,
                                                       this.transform.localPosition.z + moveZ);

        }
    }
}