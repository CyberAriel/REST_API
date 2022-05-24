namespace REST_API.Models
{
    public class TimeRepository
    {
        List <DateTime> TimeList = new List<DateTime> ();

        public DateTime ShowTime()
        {
            DateTime date = DateTime.Now;
            AddTime (date);
            return TimeList.LastOrDefault();
        }
        public void AddTime(DateTime item)
        {
            TimeList.Add (item);
        }




    }
}
