using UnityEngine;

namespace UnfinishedStudios.MegaSprings
{
    public class NullService : Schedule
    {
        public override void TickSchedule() { Log.kill("Locator could not find an appropiate service for Schedule."); }
    }
}