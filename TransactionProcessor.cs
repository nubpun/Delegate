using System;

namespace observ
{
    public abstract class TransactionProcessor<TRequest, TSave>
    {
        Handler<bool> Check;
        Handler<Transaction> Register;
        SaveHandler<Transaction> Save;
        public TransactionProcessor(Handler<bool> Check, Handler<Transaction> Register, SaveHandler<Transaction> Save)
        {
            this.Check = Check;
            this.Register = Register;
            this.Save = Save;
        }

        public Transaction Process(TRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }

        public delegate T Handler<T>(TRequest request);
        public delegate void SaveHandler<T>(T result);
    }
   
    public class Transaction
    {
    }

    public class TransactionRequest
    {
    }
}
