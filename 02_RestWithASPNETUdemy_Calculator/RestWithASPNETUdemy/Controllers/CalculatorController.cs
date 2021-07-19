using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{fristNumber}/{secondNumber}")]
        public IActionResult Get(string fristNumber, string secondNumber)
        {
            if (Isnumeric(secondNumber) && Isnumeric(fristNumber))
            {
                var sum = ConvertToDecimal(fristNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        private bool Isnumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                            System.Globalization.NumberStyles.Any,
                            System.Globalization.NumberFormatInfo.InvariantInfo,
                            out number);
            return isNumber;

        }

        private decimal ConvertToDecimal(string srtNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(srtNumber, out decimalValue)) {
                return decimalValue;
            }
            return 0;
        }
    }
}
