using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcanumIsland.Core.Logging
{
    public interface ILogger
    {
        public void Info(string message);
        public void Warning(string message);
        public void Error(string message);
        public void Error(Exception e);
    }
}
