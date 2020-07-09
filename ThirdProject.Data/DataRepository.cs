namespace ThirdProject.Data
{
    public class DataRepository
    {
        public static CodeCategoryData CodeCategory { get; set; } = new CodeCategoryData();
        public static CodeData Code { get; set; } = new CodeData();
        public static MemberData Member { get; set; } = new MemberData();
        public static RestaurantData Restaurant { get; set; } = new RestaurantData();
        public static ReviewData Review { get; set; } = new ReviewData();
        public static RegistrationData Registration { get; set; } = new RegistrationData();
        public static InformationData Information { get; set; } = new InformationData();
        public static MenuData Menu { get; set; } = new MenuData();

    }
}
