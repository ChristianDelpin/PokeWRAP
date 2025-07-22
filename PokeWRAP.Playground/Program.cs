namespace PokeWRAP.Playground
{
    using PokeWRAP.Services;
    using PokeWRAP.Models;
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Begnning test...");
            int TaskCount = 0;
            int TaskSuccess = 0;

            var service = new PokeWrapService();
            TaskCount++;
            try
            {
                Console.WriteLine("Fetching cheri berry data...");
                var berryResult = await service.GetResourceAsync<Berry>("1");
                
                Console.WriteLine($"Data fetched successfully! Raw data:\n{berryResult}");
                var growthTime = berryResult.GrowthTime;
                Console.WriteLine($"First berry growth time: {growthTime} minutes");
                TaskSuccess++;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP Request failed: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            
            TaskCount++;
            try
            {
                Console.Write("\n\nEnter berry id (1-64) or name: ");
                var input = Console.ReadLine();
                Console.WriteLine();
                var result = await service.GetResourceAsync<Berry>(input);
                
                Console.WriteLine($"Data fetched successfully! Raw data:\n{result}");
                var specificBerry = result.Name;
                Console.WriteLine($"First Pokemon name: {specificBerry}");
                TaskSuccess++;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP Request failed: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }




            Console.WriteLine($"Test completed. Success rate: {TaskSuccess}/{TaskCount} ({(TaskSuccess/TaskCount)*100}%)");
        }
    }
}