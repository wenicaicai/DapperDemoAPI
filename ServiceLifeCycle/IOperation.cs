using System;

namespace ServiceLifeCycle
{
    public interface IOperation
    {
        Guid OperationId { get; set; }
    }

    //瞬时 无状态的服务
    public interface IOperationTransient : IOperation
    { 
    
    }

    //作用域 
    public interface IOperationScoped : IOperation
    { 
    
    }

    //
    public interface IOperationSingleton : IOperation
    { 
    
    }
}
