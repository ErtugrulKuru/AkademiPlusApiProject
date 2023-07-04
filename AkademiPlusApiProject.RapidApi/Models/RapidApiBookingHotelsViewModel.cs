namespace AkademiPlusApiProject.RapidApi.Models
{
    public class RapidApiBookingHotelsViewModel
    {
        public Result[] result { get; set; }      
        public class Result
        {
            public string hotel_name { get; set; }
            public float? review_score { get; set; }
        }
    }
}
