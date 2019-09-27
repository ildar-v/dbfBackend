namespace VolunteerSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IRating : IBusinessModel
    {
        RatingLabel Value { get; set; }
    }
}
