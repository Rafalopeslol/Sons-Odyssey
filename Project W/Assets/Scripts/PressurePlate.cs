using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public ProtectPlate protect1;
    public ProtectPlate protect2;
    public string Type;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(Type == "Single")
        {
            protect1.moveDown = false;
            protect1.moveUp = true;
        }
        if(Type == "Double")
        {
            protect1.moveDown = false;
            protect1.moveUp = true;

            protect2.moveDown = true;
            protect2.moveUp = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (Type == "Single")
        {
            protect1.moveUp = false;
            protect1.moveDown = true;
        }
        if (Type == "Double")
        {
            protect1.moveDown = true;
            protect1.moveUp = false;

            protect2.moveDown = false;
            protect2.moveUp = true;
        }
    }
}
