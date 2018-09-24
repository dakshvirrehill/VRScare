using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
	public GameObject kpp;
	public GameObject d;
	//public bool HasKey = false;
	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
		Object.Instantiate(kpp,transform.position,Quaternion.Euler(-90,0,0));
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
		d.GetComponent<Door>().Unlock();
        // Set the Key Collected Variable to true
		//HasKey=true;
        // Destroy the key. Check the Unity documentation on how to use Destroy
		Destroy(gameObject);
    }

}
