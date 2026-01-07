namespace SDCPervomay.AppData
{
    internal class SupportModels
    {
        public class ScheduleModel
        {
            public string Name { get; set; }
            public string Time { get; set; }
            public string Coach { get; set; }
            public string Image { get; set; }
        }

        public class CustomerModel
        {
            public int Id { get; set; }
            public string Fullname { get; set; }
            public string Contact { get; set; }
        }

        public class LockersModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
            public string Fullname { get; set; }
            public int LockerRoomId { get; set; }
        }
    }
}
