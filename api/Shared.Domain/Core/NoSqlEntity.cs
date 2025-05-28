using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shared.Domain.Core
{
    public class NoSqlEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as NoSqlEntity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
