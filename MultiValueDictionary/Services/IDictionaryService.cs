namespace MultiValueDictionary.Services
{
    public interface IDictionaryService
    {
        /// <summary>
        /// Entrypoint to the dictionary service.
        /// The program will run in a loop awaiting input and returning a response and so on until it is exited or told to run a single loop.
        /// </summary>
        /// <param name="singleLoop">When true the program will only run once instead of a loop</param>
        public void Run(bool singleLoop);
    }
}