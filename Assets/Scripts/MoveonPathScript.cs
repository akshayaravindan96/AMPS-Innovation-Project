using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveonPathScript : MonoBehaviour {

    public EditorPathScript PathToFollow;
    int flag = 0;
    public int CurrentWayPointID = 0;
    public float speed = 1;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;
    public float str = 10f;
    public Collider tote;
    public Camera front;
    public Camera back;
    public Camera rightside;
    public Camera leftside;
    public Camera top;

    Vector3 last_position;
    Vector3 current_position;
    Vector3 tote_position;

	void Start () {
        //PathToFollow = GameObject.Find(pathName).GetComponent<EditorPathScript> ();
        last_position = transform.position;
	}
	
	
	void Update () {
        //Camera toggling
        if(Input.GetKeyDown("1"))
        {
            front.enabled = true;
            back.enabled = false;
            rightside.enabled = false;
            leftside.enabled = false;
            top.enabled = false;
        }
        if (Input.GetKeyDown("2"))
        {
            front.enabled = false;
            back.enabled = true;
            rightside.enabled = false;
            leftside.enabled = false;
            top.enabled = false;
        }
        if (Input.GetKeyDown("3"))
        {
            front.enabled = false;
            back.enabled = false;
            rightside.enabled = true;
            leftside.enabled = false;
            top.enabled = false;
        }
        if (Input.GetKeyDown("4"))
        {
            front.enabled = false;
            back.enabled = false;
            rightside.enabled = false;
            leftside.enabled = true;
            top.enabled = false;
        }
        if (Input.GetKeyDown("5"))
        {
            front.enabled = false;
            back.enabled = false;
            rightside.enabled = false;
            leftside.enabled = false;
            top.enabled = true;
        }

        if (CurrentWayPointID == 3)
            speed = 3;
        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime*speed);

        var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        if(distance <= reachDistance)
        {
            CurrentWayPointID++;
        }
        
        if(CurrentWayPointID >= PathToFollow.path_objs.Count)
        {
            //CurrentWayPointID = 0;
        }
        if(flag!=0)
        {
            Rigidbody body = tote.attachedRigidbody;
            tote_position = new Vector3(transform.position.x , transform.position.y + 2.2f, transform.position.z+ 0.2f);
            tote.gameObject.transform.position = Vector3.MoveTowards(tote.gameObject.transform.position, tote_position, 2);
            
            tote.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        if(CurrentWayPointID==10)
        {
            speed = 1;
        }
        if(CurrentWayPointID==11)
        {

            tote.gameObject.SetActive(false);
            
        }
        if(CurrentWayPointID==13)
        {
            speed = 3;
        }
	}



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Tote"))
        {
            //other.gameObject.SetActive(false);
            flag = 1;
        }
    }
}
