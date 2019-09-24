using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace Tests.Business
{
    public class Customer
    {
        private readonly ILogger _logger;
        private readonly IDbGateway _gateway;

        public Customer(IDbGateway gateway, ILogger logger)
        {
            _logger = logger;
            _gateway = gateway;
        }
        public decimal CalculateWage(int id)
        {
            WorkingStatistics ws = _gateway.GetWorkingStatistics(id);

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

    internal interface ILogger
    {
        void Info(string s);
    }

    internal class Logger : ILogger
    {
        public void Info(string s)
        {
            File.WriteAllText(@"C:\tmp:\log.txt", s);
        }
    }

    public interface IDbGateway
    {
        WorkingStatistics GetWorkingStatistics(int id);
    }

    public class DbGateway : IDbGateway
    {
        public WorkingStatistics GetWorkingStatistics(int id)
        {
            throw new NoConnection();
        }
    }

    public class NoConnection
    {

    }
}
