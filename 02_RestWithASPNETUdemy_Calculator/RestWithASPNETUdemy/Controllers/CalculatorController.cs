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
        public IActionResult Sum(string fristNumber, string secondNumber)
        {
            if (Isnumeric(secondNumber) && Isnumeric(fristNumber))
            {
                var sum = ConvertToDecimal(fristNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("subtraction/{fristNumber}/{secondNumber}")]
        public IActionResult Subtraction(string fristNumber, string secondNumber)
        {
            if (Isnumeric(secondNumber) && Isnumeric(fristNumber))
            {
                var sum = ConvertToDecimal(fristNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{fristNumber}/{secondNumber}")]
        public IActionResult Multiplication(string fristNumber, string secondNumber)
        {
            if (Isnumeric(secondNumber) && Isnumeric(fristNumber))
            {
                var sum = ConvertToDecimal(fristNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{fristNumber}/{secondNumber}")]
        public IActionResult Mean(string fristNumber, string secondNumber)
        {
            if (Isnumeric(secondNumber) && Isnumeric(fristNumber))
            {
                var mean = (ConvertToDecimal(fristNumber) * ConvertToDecimal(secondNumber))/2;
                return Ok(mean.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("division/{fristNumber}/{secondNumber}")]
        public IActionResult Division(string fristNumber, string secondNumber)
        {
            if (Isnumeric(secondNumber) && Isnumeric(fristNumber))
            {
                var division = (ConvertToDecimal(fristNumber) / ConvertToDecimal(secondNumber)) ;
                return Ok(division.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("square-root/{fristNumber}")]
        public IActionResult SquareRoot(string fristNumber)
        {
            if (Isnumeric(fristNumber))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(fristNumber)) ;
                return Ok(squareRoot.ToString());
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
