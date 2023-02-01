using Lesson_12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lesson_12.Models
{
    public class Deposit : Account, IAccount<Account>
    {
        public Deposit(object number, object balance) : base(number, balance)
        {
        }
    }
}
