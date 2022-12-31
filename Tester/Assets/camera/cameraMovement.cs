
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public Transform Player;

    void FixedUpdate()
    {
    transform.position = Player.position+new Vector3(0,0,-10);
    }
}