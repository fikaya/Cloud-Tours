using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Management.Application
{
    //Command Result Create,Delete,Update işlemlerinde kullanılıyor. 
    public class CommandResult
    {
        public CommandResult()
        {
            Messages = new List<string>();
        }
        public bool IsSucceeded { get; set; }
        public ICollection<string> Messages { get; }//_messages= new List<string>();

        //Factory Pattern(Bir metot içinde metodun temsil edildiği sınıfın örneklemesini alma şekli)
        public static CommandResult Success(params string[] messages) 
        {
            var result = new CommandResult()
            {
                IsSucceeded = true
            };

            if (messages!=null)
            {
                foreach (var item in messages)
                {
                    result.Messages.Add(item);
                }
            }

            return result;
        }

        public static CommandResult Error(params string[] messages)
        {
            var result = new CommandResult() 
            { 
                IsSucceeded = false 
            };

            if (messages!=null)
            {
                foreach (var item in messages)
                {
                    result.Messages.Add(item);
                }
            }

            return result;

        }
    }
}
