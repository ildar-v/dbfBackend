namespace Volunteer.BLModels.Interfaces
{
    using Entities;

    public interface IReport : IEntity, IRatingable
    {
        Activity Activity { get; set; }
        string Description { get; set; }
    }
}
