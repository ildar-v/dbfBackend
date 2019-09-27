using System;
using System.Collections.Generic;
using System.Linq;

namespace Volunteer.MainModule.Managers.DataManagers.Filters
{
    public class Filter
    {
        private bool multiple = false;
        private Dictionary<string, object[]> filterParams = null;
        public Filter(string attributeName, params object[] value)
        {
            filterParams = new Dictionary<string, object[]>
            {
                { attributeName, value }
            };
        }
        public Filter(Dictionary<string, object[]> filterParams)
        {
            this.filterParams = filterParams;
        }

        public bool Multiple { get; }
        public Dictionary<string, object[]> FilterParams { get; }

        public bool Check<T>(object verifiable)
        {
            if (verifiable.GetType() != typeof(T))
            {
                return false;
            }

            if (!this.Multiple && this.FilterParams.Any())
            {
                var param = this.FilterParams.First();
                var propertyValue = verifiable.GetType().GetProperty(param.Key).GetValue(verifiable);
                return param.Value.Any(v => Compare(v, propertyValue));
            }
            foreach (var param in this.FilterParams)
            {
                var propertyValue = verifiable.GetType().GetProperty(param.Key).GetValue(verifiable);
                if (!param.Value.Any(v => Compare(v, propertyValue)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool Compare(object first, object second)
        {
            if (first is IComparable comparableX && second is IComparable comparableY)
            {
                return comparableX.CompareTo(second) == default(int);
            }
            return first == second;
        }
    }
}
