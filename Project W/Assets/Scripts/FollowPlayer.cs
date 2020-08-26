using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0, -1);
    public Vector3 minPosition;
    public Vector3 maxPosition;
    Transform mainPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainPlayer = SwitchPlayer.mainPlayer;
        if (mainPlayer)
        {
            transform.position = new Vector3(
                mainPlayer.transform.position.x + offset.x,
                mainPlayer.transform.position.y + offset.y,
                mainPlayer.transform.position.z + offset.z);

        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y),
            Mathf.Clamp(transform.position.z, minPosition.z, maxPosition.z));

    }
}
