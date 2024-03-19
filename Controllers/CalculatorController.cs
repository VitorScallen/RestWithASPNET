using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
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

        [HttpGet("sum/{firtsNumber}/{secondNumber}")]
        public IActionResult Get(string firtsNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firtsNumber))
            {
                var sum = ConvertToDeciaml(firtsNumber) + ConvertToDeciaml(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                return Ok(result.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivision(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (Convert.ToDecimal(secondNumber) != 0)
                {
                    var result = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
                    return Ok(result.ToString());
                }
                else
                {
                    return BadRequest("Division by zero is not allowed");
                }
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("percentage/{number}/{percentage}")]
        public IActionResult GetPercentage(string number, string percentage)
        {
            if (IsNumeric(number) && IsNumeric(percentage))
            {
                var result = Convert.ToDecimal(number) * (Convert.ToDecimal(percentage) / 100);
                return Ok(result.ToString());
            }

            return BadRequest("Invalid input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;

            throw new NotImplementedException();
        }

        private decimal ConvertToDeciaml(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }


    }
}
