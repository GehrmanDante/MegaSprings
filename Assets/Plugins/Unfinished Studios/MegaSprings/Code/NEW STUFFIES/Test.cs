using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnfinishedStudios.MegaSprings;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ScheduleLocator.Provide(new NullService());
	}
	
	// Update is called once per frame
	void Update () {
		ScheduleLocator.GetSchedule().TickSchedule();
	}
}
