using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trickshot : MonoBehaviour
{

    bool isDragging = false;
    Vector2 origPosition;
    Vector2 newPosition;
    float time1 = 0f;
    float time2 = 0f;

    void OnMouseDrag()
    {
        if(!isDragging) {
            isDragging = true;
            origPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            time1 = Time.time;
        }
    }

    void OnMouseUp() {
        Debug.Log("Up");
        isDragging = false;
        newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        time2 = Time.time;
        Vector2 distance = origPosition - newPosition;
        float velocity = distance.magnitude / (time2 - time1);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = new Vector3(velocity*0.01f,0,0);
    }



}
