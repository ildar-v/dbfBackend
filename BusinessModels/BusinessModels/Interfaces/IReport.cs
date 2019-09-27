namespace Volunteer.BusinessModels.Interfaces
{
    public interface IReport : IBusinessModel, IRatingable
    {
        Activity Activity { get; set; }
        string Description { get; set; }
    }
}
