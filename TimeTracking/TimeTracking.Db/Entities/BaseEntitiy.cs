using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracking.Db.Entities
{
    public abstract class BaseEntitiy
    {
        public int Id { get; set; }
        public abstract string PrintInfo();
    }
}
