using System.Collections.Generic;
using System.Linq;

namespace LanguageLearning.Domain.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var valueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(0, (hash, obj) => hash ^ (obj?.GetHashCode() ?? 0));
        }
    }
}
