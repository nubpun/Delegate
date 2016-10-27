using System;

namespace observ
{
    public abstract class TransactionProcessor<TRequest, TSave>
    {
        Handler<bool> Check;
        Handler<TSave> Register;
        SaveHandler Save;
        public TransactionProcessor(Handler<bool> Check, Handler<TSave> Register, SaveHandler Save)
        {
            this.Check = Check;
            this.Register = Register;
            this.Save = Save;
        }

        public TSave Process(TRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }

        public delegate T Handler<T>(TRequest request);
        public delegate void SaveHandler(TSave result);
    }
   
    public class Transaction
    {
    }

    public class TransactionRequest
    {
    }
}
