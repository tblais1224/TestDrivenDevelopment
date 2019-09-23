using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace Tests.Business
{
    public class Customer
    {
        private readonly Logger _logger = new Logger();

        public decimal CalculateWage(int id)
        {
            DbGateway gateway = new DbGateway();
            WorkingStatistics ws = gateway.GetWorkingStatistics(id);

            decimal wage;
            if (ws.PaytHourly)
            {
                wage = ws.WorkingHours * ws.HourSalary;
            }
            else
            {
                wage = ws.MonthlySalary;
            }

            _logger.Info($"Customer ID={id}, Wage:{wage}");
            return wage;
        }
    }
}
