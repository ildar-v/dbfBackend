using System.Collections.Generic;
using Volunteer.BLModels.Entities;

namespace Volunteer.BLModels.Interfaces
{
    public interface IEvaluated
    {
        IEnumerable<Mark> Marks { get; set; }
    }
}
