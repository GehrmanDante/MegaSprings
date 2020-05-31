using UnityEngine;

namespace UnfinishedStudios.MegaSprings
{
    public class ScheduleLocator : MonoBehaviour
    {
        private static Schedule schedule;

        private void Awake() { schedule = new ScheduleService(); }

        public static void Provide(Schedule newSchedule)
        {
			//Use a null service to avoid errors.
			if(newSchedule == null)
				newSchedule = new NullService();

            schedule = newSchedule;
        }

        public static Schedule GetSchedule() { return schedule; }
    }
}