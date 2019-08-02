using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy_with_tote_path : MonoBehaviour {

    public EditorPathScript PathToFollow;
    int flag = 0;
    public int CurrentWayPointID = 0;
    public float speed = 1;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;
    public Collider tote_being_carried;
    public Collider tote_on_stand;

    public Camera tote;
    
    Vector3 last_position;
    Vector3 current_position;
    Vector3 tote_position;
    // Use this for initialization
    void Start () {
        last_position = transform.position;
        tote_on_stand.gameObject.SetActive(false);
     
    }
	
	// Update is called once per frame
	void Update () {
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
            //CurrentWayPointID = 0;
        }
        if(CurrentWayPointID==8)
        {
            tote_being_carried.gameObject.SetActive(false);
            tote_on_stand.gameObject.SetActive(true);
        
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            tote_being_carried.gameObject.SetActive(false);
            tote_on_stand.gameObject.SetActive(true);
            flag = 1;
        }

    }
}
