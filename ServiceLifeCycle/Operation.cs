using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLifeCycle
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public Operation() : this(Guid.NewGuid())
        {

        }

        public Operation(Guid id)
        {
            OperationId = id;
        }

        public Guid OperationId { get; set; }
    }
}
