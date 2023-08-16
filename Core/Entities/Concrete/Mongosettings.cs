using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
        public class Mongosettings
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }

        #region Const Values

        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(DatabaseName);

        #endregion
    }
}
