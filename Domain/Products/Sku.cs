namespace Domain.Product
{
    // Stock Keeping Unit
    public record Sku
    {
        const int DefaultLength = 15;
        private string Value { get; init; }
        private Sku(string value) => Value = value;
        public static Sku Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            if (value.Length != DefaultLength)
                throw new InvalidDataException(nameof(value));


            return new Sku(value);
        }
    }
}
