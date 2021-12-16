using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*THIS SCRIPT WAS NOT MADE BY ME, IT CAME WITH THE ASSET PACK*//

public class DoorTrigger : MonoBehaviour
{
    private Door door;

    void Start()
    {
        door = GetComponentInParent<Door>();
    }

    void OnTriggerEnter(Collider c) {

        door.openDoor(c);

    }

    void OnTriggerExit(Collider c) {
        door.closeDoor(c);
    }
}
