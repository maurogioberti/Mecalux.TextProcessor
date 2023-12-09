using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.CrossCutting.Globalization;
using Mecalux.TestProcessor.CrossCutting.Utils.Constants;
using Mecalux.TestProcessor.ResourceAccess.Contracts;
using Mecalux.TestProcessor.ResourceAccess.Contracts.Collections;
using Mecalux.TestProcessor.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Mecalux.TestProcessor.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextController : ControllerBase
    {
        private readonly ITextService textService;
        private readonly ITextSortService textSortService;

        public TextController(ITextService textService,
                                ITextSortService textSortService)
        {
            this.textService = textService;
            this.textSortService = textSortService;
        }

        [HttpGet("Options")]
        [Produces("application/json", "application/xml")]
        public SortCollection GetOptions()
        {
            return textSortService.List();
        }

        [HttpGet("Statistics")]
        [Produces("application/json", "application/xml")]
        public Statistics GetStatistics([FromQuery] string textToAnalyze)
        {
            return textService.GetStatistics(textToAnalyze);
        }

        [HttpGet("OrderedText")]
        [Produces("application/json", "application/xml")]
        public IActionResult GetOrderedText([FromQuery] string textToOrder, string orderOption)
        {
            if (Enum.TryParse(orderOption, true, out SortOption orderOptionEnum))
            {
                var sortedText = textSortService.Sort(textToOrder, orderOptionEnum);
                return Ok(sortedText);
            }

            var validOptions = string.Join($"{TextConstants.Comma}{TextConstants.Space}", Enum.GetNames(typeof(SortOption)));
            return BadRequest($"{Messages.InvalidOrderOption}{TextConstants.Space}{validOptions}{TextConstants.Period}");
        }

    }
}