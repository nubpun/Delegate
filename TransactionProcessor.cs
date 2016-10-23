using System;

namespace work
{
    public abstract class TransactionProcessor
    {
        public Transaction Process(TransactionRequest request, Handler<bool> Check, Handler<Transaction> Register, SaveHandler Save)
        {

            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }
        public delegate T OrderHandler<T>(Item item);
        public delegate T Handler<T>(TransactionRequest request);
        public delegate void SaveHandler(Transaction transaction);
        //protected abstract bool Check(TransactionRequest request);
        //protected abstract Transaction Register(TransactionRequest request);
        //protected abstract void Save(Transaction transaction);
    }

    public class Item
    {
    }
   
    public class Transaction
    {
    }

    public class TransactionRequest
    {
    }
}
