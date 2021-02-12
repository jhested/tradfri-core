namespace Tradfri.Client
{
    public class StringStatic
    {
        protected readonly string _value;

        protected StringStatic(string value)
        {
            _value = value;
        }

        public static implicit operator string(StringStatic d) => d._value;
        public static explicit operator StringStatic(string b) => new StringStatic(b);

        public override string ToString() => $"{_value}";
    }
}
