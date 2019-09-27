namespace VolunteerSystem
{
    public interface IReport : IBusinessModel
    {
        Activity Activity { get; set; }
        string Description { get; set; }
        IRating Rating { get; set; }
    }
}
