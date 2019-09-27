namespace Volunteer.BusinessModels.Interfaces
{
    public interface IRating : IBusinessModel
    {
        RatingLabel Value { get; set; }
    }
}
