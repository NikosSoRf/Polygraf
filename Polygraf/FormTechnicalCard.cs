using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygraf
{
    public partial class FormTechnicalCard : Form
    {
        public FormTechnicalCard()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter dataTechnicalCard = new SqlDataAdapter();
        SqlDataAdapter dataContract = new SqlDataAdapter();
        SqlDataAdapter dataInclude = new SqlDataAdapter();
        

        private void FormTechnicalCard_Load(object sender, EventArgs e)
        {
            string str = ConfigurationManager.ConnectionStrings["Polygraf"].ConnectionString;
            cnn = new SqlConnection(str);
            cnn.Open();
        }
    }
}
