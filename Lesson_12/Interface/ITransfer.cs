using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_12.Models;

namespace Lesson_12.Interface
{
    public interface ITransfer<in T1, in T2> where T1 : Account where T2 : Account
    {
        public void Post(Account acc_out, Account acc_in, decimal sum);
    }
}
