using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrap : MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        // Convert world point to viewport so it's in 0->1 range.
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 moveAdjustment = Vector3.zero;
        if (viewportPosition.x < 0) {
            moveAdjustment.x += 1;           
        } else if (viewportPosition.x >1) {
            moveAdjustment.x -= 1;
            
        }else if (viewportPosition.y <0) {
            moveAdjustment.y += 1;


        } else if (viewportPosition.y >1) {
            moveAdjustment.y -= 1;
        }
            transform.position = Camera.main.ViewportToWorldPoint(viewportPosition + moveAdjustment);


            }
}
