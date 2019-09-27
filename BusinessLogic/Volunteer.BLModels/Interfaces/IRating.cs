namespace Volunteer.BLModels.Interfaces
{
    using Entities;

    public interface IRating : IEntity
    {
        RatingLabel Value { get; set; }
    }
}
