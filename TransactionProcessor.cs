using System;

namespace observ
{
    public abstract class TransactionProcessor
    {
        //Handler<Transaction, T>
        
        public Transaction Process<TRequest>(TRequest request, Handler<bool, TRequest> Check, Handler<Transaction, TRequest> Register, SaveHandler Save)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }
        public delegate T Handler<T, TRequest>(TRequest request);
        public delegate void SaveHandler(Transaction transaction);
    }
   
    public class Transaction
    {
    }

    public class TransactionRequest
    {
    }
}
