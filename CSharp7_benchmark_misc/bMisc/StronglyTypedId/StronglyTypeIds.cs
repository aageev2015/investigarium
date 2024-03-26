// template taken from https://thomaslevesque.com/2020/10/30/using-csharp-9-records-as-strongly-typed-ids/
namespace bMisc.StronglyTypedId
{
    public readonly struct ManualReadonlyStructEntityId(Guid value) : IEquatable<ManualReadonlyStructEntityId>
    {
        public Guid Value { get; } = value;

        public static ManualReadonlyStructEntityId New() => new ManualReadonlyStructEntityId(Guid.NewGuid());

        public bool Equals(ManualReadonlyStructEntityId other) => other.Value == Value;
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj) => obj is ManualReadonlyStructEntityId other && Equals(other);
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => $"ManualReadonlyStructEntityId {Value}";
        public static bool operator ==(ManualReadonlyStructEntityId a, ManualReadonlyStructEntityId b) => a.Equals(b);
        public static bool operator !=(ManualReadonlyStructEntityId a, ManualReadonlyStructEntityId b) => !a.Equals(b);
    }

    public struct ManualStructEntityId(Guid value) : IEquatable<ManualStructEntityId>
    {
        public Guid Value { get; } = value;

        public static ManualStructEntityId New() => new ManualStructEntityId(Guid.NewGuid());

        public readonly bool Equals(ManualStructEntityId other) => other.Value == Value;
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override readonly bool Equals(object obj) => obj is ManualStructEntityId other && Equals(other);
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override readonly int GetHashCode() => Value.GetHashCode();
        public override readonly string ToString() => $"ManualStructEntityId {Value}";
        public static bool operator ==(ManualStructEntityId a, ManualStructEntityId b) => a.Equals(b);
        public static bool operator !=(ManualStructEntityId a, ManualStructEntityId b) => !a.Equals(b);
    }

    public class ManualClassEntityId(Guid value) : IEquatable<ManualClassEntityId>
    {
        public Guid Value { get; } = value;

        public static ManualClassEntityId New() => new ManualClassEntityId(Guid.NewGuid());

        public bool Equals(ManualClassEntityId? other) => other?.Value == Value;
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj) => obj is ManualClassEntityId other && Equals(other);
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => $"ManualClassEntityId {Value}";
        public static bool operator ==(ManualClassEntityId a, ManualClassEntityId b) => a.Equals(b);
        public static bool operator !=(ManualClassEntityId a, ManualClassEntityId b) => !a.Equals(b);
    }

    public record RecordClassEntityId(Guid Value);

    public record struct RecordStructEntityId(Guid Value);

    public static class RecordEntityId
    {
        public static RecordClassEntityId NewClass() => new(Guid.NewGuid());
        public static RecordStructEntityId NewStruct() => new(Guid.NewGuid());
    }
}
