using System;

namespace observ
{
    public abstract class TransactionProcessor
    {
        public Transaction Process<TRequest, TSave>(TRequest request, Handler<bool, TRequest> Check, Handler<Transaction, TRequest> Register, SaveHandler<Transaction> Save)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }
        public delegate T Handler<T, TRequest>(TRequest request);
        public delegate void SaveHandler<T>(T transaction);
    }
   
    public class Transaction
    {
    }

    public class TransactionRequest
    {
    }
}
