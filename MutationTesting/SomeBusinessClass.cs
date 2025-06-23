namespace MutationTesting
{
    public class SomeBusinessClass
    {
        private ISomeInterface _someInterface;
        public SomeBusinessClass(ISomeInterface someInterface)
        {
            _someInterface = someInterface ?? throw new ArgumentNullException(nameof(someInterface));
        }
        public int SomeMethod(int x, int y)
        {
            return x + y;
        }
        
        public async Task<string> SomeOtherMethod(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty", nameof(input));
            }

            if (input.Equals("Larry"))
            {
                _someInterface.SomeCallAsync("no");
            }
            
            string transformedString = input.ToUpper();
            await _someInterface.SomeCallAsync(transformedString);
            return transformedString;
        }
    }
    
    public interface ISomeInterface
    {
        Task SomeCallAsync(string x);
    }
}
