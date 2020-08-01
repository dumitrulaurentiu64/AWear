using AWear_API.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWear_API.Hubs
{
    public interface ISensorDataHub {
        Task SensorDataUpdate(Guid id, DateTime TimeStamp, double Temperature, double Humidity, double Pulse, double EKGValue);
    }
    public class SensorDataHub : Hub<ISensorDataHub>
    {
    }
}
