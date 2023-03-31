using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTax
{
    public class TaxModel
    {
        public int Income { get; set; }
        public SalaryInsuranceType SalaryInsurance { get; set; }
        public AreaType Area { get; set; }
        public int NumberOfDependent { get; set; }
    }
    public enum SalaryInsuranceType : byte
    {
        OfficalSalary = 1,
        Other = 2,
    }
    public enum AreaType : byte
    {
        I = 1,
        II = 2,
        III = 3,
        IV = 4
    }
}
