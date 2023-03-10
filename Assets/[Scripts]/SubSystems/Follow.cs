//Follow
//LastUpdate 22_12_15
//Daekoen_Lee 101076401
//Revision History
//First modified 22_12_15
//Description - Follow - Following health UI
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Target
{
    public Transform transform;
    public Vector2 offset;
    public bool x;
    public bool y;
}


[ExecuteInEditMode]
public class Follow : MonoBehaviour
{
    public Target target;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            (target.x) ? target.transform.position.x + target.offset.x : transform.position.x,
            (target.y) ? target.transform.position.y + target.offset.y : transform.position.y,
            transform.position.z
        );
    }
}
