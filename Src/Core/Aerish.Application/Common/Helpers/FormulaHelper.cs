using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aerish.Application.Common.Helpers
{
    public abstract class FormulaHelper
    {
        public static decimal Calculate(string formula, Dictionary<string, decimal> variables)
        {
            string fmla = formula;

            try
            {

                foreach (string item in variables.Keys)
                {
                    string key = item.Trim('{', '}');

                    fmla = fmla.Replace("{" + key + "}", variables[item].ToString(), StringComparison.OrdinalIgnoreCase);
                }

                var result = new DataTable().Compute(fmla, null);

                return Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                throw new AerishException($"Unable to calculate expression: ({fmla}) with variables {JsonSerializer.Serialize(variables)}", ex);
            }
        }
    }
}
