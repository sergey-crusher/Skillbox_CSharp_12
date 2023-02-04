using Lesson_12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_12.Models
{
    public class Transfer : ITransfer<Account, Account>
    {
        public void Post(Account acc_out, Account acc_in, decimal sum)
        {
            acc_out.Balance = (decimal)acc_out.Balance - sum;
            acc_in.Balance = (decimal)acc_in.Balance + sum;
        }
    }
}
