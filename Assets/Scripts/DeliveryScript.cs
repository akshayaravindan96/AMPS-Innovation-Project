using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryScript : MonoBehaviour {
    int flag = 0;
    int flag2 = 0;
    public EditorPathScript PathToFollow;
   
    public int CurrentWayPointID = 0;
    public float speed = 1;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;
    
    Vector3 last_position;
    Vector3 current_position;
    Vector3 tote_position;
    // Use this for initialization
    void Start () {
        last_position = transform.position;
       
    }
	
	// Update is called once per frame
	void Update () {
        if(flag==1)
        {
            float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);

            var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            if (distance <= reachDistance)
            {
                CurrentWayPointID++;
            }

            if (CurrentWayPointID >= PathToFollow.path_objs.Count)
            {
                CurrentWayPointID = PathToFollow.path_objs.Count;
            }
        }
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("delivery"))
        {
            //other.gameObject.SetActive(false);
            flag = 1;
        }
        
    }
    
}
