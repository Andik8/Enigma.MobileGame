/*		Script contains
		           ***
	                Array for slots
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    // Start is called before the first frame update
    
}
public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }
    void OnPickup();

}
