namespace Volunteer.BLModels.Interfaces
{
    using Entities;

    public interface IReport : IEntity, IEvaluated
    {
        Activity Activity { get; set; }
        string Description { get; set; }
    }
}
