using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Domain.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public Type Type { get; set; }
        public int Id { get; set; }
        public EntityNotFoundException(Type Type, int Id, string Message): base(Message) { 
            this.Type = Type;
            this.Id = Id;
        }
    }
}
