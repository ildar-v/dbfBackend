namespace VolunteerSystem.Interfaces
{
    public interface IRating : IBusinessModel
    {
        RatingLabel Value { get; set; }
    }
}
