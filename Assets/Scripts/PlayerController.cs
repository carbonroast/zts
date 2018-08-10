using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour {

    public Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //test tile location
        if (Input.GetKeyDown("r"))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 mousecoord = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
            
            RaycastHit2D hit2d = Physics2D.GetRayIntersection(ray);
            Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 5);
            if(hit2d.collider != null)
            {
                GridLayout grid = hit2d.transform.GetComponentInParent<GridLayout>();
                Debug.Log("clicked - " + mousecoord + " " + hit2d.collider.name);
                Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
                Vector3Int position = grid.WorldToCell(worldPoint);
                Debug.Log(position);
            }
            if(Physics.Raycast(ray,out hit, 100))
            {
                Debug.Log("hit - " + hit.transform.name);
            }
        }
	}
}
