using Microsoft.AspNetCore.Mvc;

namespace FlightFinder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightFinderController : ControllerBase
    { 
        private readonly ILogger<FlightFinderController> _logger;
        private readonly string _word = "flight";

        public FlightFinderController(ILogger<FlightFinderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get([FromQuery] string input)
        {
            _logger.LogInformation("Original input: {input}", input);

            // Filter input string to only keep characters that are in the specified word
            var filtered = new string(input.Where(c => _word.Contains(c)).ToArray()) ?? "";

            // If word cannot possibly be formed from input string based on length
            if (filtered.Length < _word.Length)
                return 0;

            // Pop the word from the input string until no more can be done
            var count = 0;
            while (PopWord(ref filtered))
            {
                count++;
                _logger.LogInformation("{wordCount} words popped from input", count);
            }

            _logger.LogInformation("Final word count: {count}", count);

            return count;
        }

        /// <summary>
        /// Pops (removes and uses) each character from the input string to form the full word
        /// </summary>
        /// <param name="input">Input string passed as reference</param>
        /// <returns>True if the full word was found in the specified input string, otherwise false</returns>
        [NonAction]
        public bool PopWord(ref string input)
        {
            if (input.Length < _word.Length)
                return false;

            foreach (var c in _word)
            {
                var idx = input.IndexOf(c);

                // If the character is not found in the string, the word cannot be completed
                if (idx == -1)
                    return false;

                // Otherwise, pull the character out of the input string and continue processing
                input = input.Remove(idx, 1);
            }

            return true;
        }
    }
}