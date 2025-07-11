using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BeyazEsyaOtomasyon
{
    public class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            return new SqlConnection(@"Data Source=RAMSES\SQLEXPRESS;Initial Catalog=DboBeyazOtomasyon;Integrated Security=True");
        }
    }
}
