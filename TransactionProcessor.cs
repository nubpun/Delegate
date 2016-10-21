using System;

namespace work
{
    public abstract class TransactionProcessor
    {
        public Transaction Process(TransactionRequest request, CheckHandler Check, RegisterHandler Register, SaveHandler Save)
        {

            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }
        public delegate bool CheckHandler(TransactionRequest request);
        public delegate Transaction RegisterHandler(TransactionRequest request);
        public delegate void SaveHandler(Transaction transaction);
        //protected abstract bool Check(TransactionRequest request);
        //protected abstract Transaction Register(TransactionRequest request);
        //protected abstract void Save(Transaction transaction);
    }

   
    public class Transaction
    {
    }

    public class TransactionRequest {
    }
}
