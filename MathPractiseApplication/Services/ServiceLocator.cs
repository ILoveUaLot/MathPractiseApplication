using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPractiseApplication.Services
{
    public class ServiceLocator
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void Initialize(ServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
