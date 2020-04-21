using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLifeCycle
{
    public class OperationService
    {
        public IOperationTransient OperationTransient { get; }
        public IOperationScoped OperationScoped { get; }
        public IOperationSingleton OperationSingleton { get; }

        public OperationService(IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton)
        {
            OperationTransient = operationTransient;
            OperationScoped = operationScoped;
            OperationSingleton = operationSingleton;
        }

    }
}
