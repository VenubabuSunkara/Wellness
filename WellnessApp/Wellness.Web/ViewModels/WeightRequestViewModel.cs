namespace Wellness.Web.ViewModels
{
    public class WeightRequestViewModel
    {
        public decimal Weight { get; set; }
        public decimal Height { get; set; } = 0;
        public decimal BodyFatPercentage { get; set; } = 0;
        public decimal MuscleMass { get; set; } = 0;
        public decimal VisceralFat { get; set; } = 0;
        public decimal BasalMetabolicRate { get; set; } = 0;
        public int MetabolicAge { get; set; } = 0;
        public decimal TrunkFatPercentage { get; set; } = 0;
        public int BMI { get; set; } = 0;
    }
}
