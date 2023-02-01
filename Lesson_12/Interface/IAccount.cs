using Lesson_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_12.Interface
{
    public interface IAccount<out T> where T : Account
    {
        //T GetValue(object number, object balance);
    }
}
