using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

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

            //Click on Tilemap
            if(hit2d.collider != null)
            {
                GridLayout grid = hit2d.transform.GetComponentInParent<GridLayout>();
                Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
                Vector3Int position = grid.WorldToCell(worldPoint);
                Vector2Int position2d = new Vector2Int(position.x, position.y);

                string netid = hit2d.collider.GetComponent<NetworkIdentity>().netId.ToString();
                SpriteTile tileClicked = SpriteTileManager.GetTile(position2d.ToString() + " " + netid);

                Debug.Log(
                    "name - " + tileClicked.name + 
                    "location - " + tileClicked.location + 
                    "buildable -" + tileClicked.buildable
                );
                //Debug.Log(position);
                //Debug.Log("clicked - " + mousecoord + " " + hit2d.collider.name);

            }
            if (Physics.Raycast(ray,out hit, 100))
            {
                Debug.Log("hit - " + hit.transform.name);
            }
        }
	}
}
