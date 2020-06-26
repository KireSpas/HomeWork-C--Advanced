namespace TimeTracking.Db.Entities
{
    public class Activities
    {
        public Reading Reading{ get; set; }
        public Exercising Exercising { get; set; }
        public Working Working { get; set; }
        public OtherHobbies OtherHobbies { get; set; }
    }
}