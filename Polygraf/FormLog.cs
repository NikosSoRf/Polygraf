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
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        DataSet ds = new DataSet();
        //SqlDataAdapter dataContract = new SqlDataAdapter();
        SqlDataAdapter dataEmployer = new SqlDataAdapter();
        SqlDataAdapter dataPosition = new SqlDataAdapter();
        private void FormLog_Load(object sender, EventArgs e)
        {
            string str = ConfigurationManager.ConnectionStrings["Polygraf"].ConnectionString;
            cnn = new SqlConnection(str);
            cnn.Open();

            dataEmployer.SelectCommand = new SqlCommand("select* from Employer", cnn);

            dataEmployer.InsertCommand = new SqlCommand("insert into Employer values(@EmployerId, @Position, @Name, @Surname, @Password, @Mail)", cnn);
            dataEmployer.InsertCommand.Parameters.Add("@EmployerId", SqlDbType.Int, 4, "EmployerId");
            dataEmployer.InsertCommand.Parameters.Add("@Position", SqlDbType.NVarChar, 50, "Position");
            dataEmployer.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "NameE");
            dataEmployer.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 50, "SurnameE");
            dataEmployer.InsertCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
            dataEmployer.InsertCommand.Parameters.Add("@Mail", SqlDbType.NVarChar, 50, "Mail");

            dataEmployer.Fill(ds, "Employer");

            bindingSource1.DataSource = ds.Tables["Emlpoyer"];

            dataPosition.SelectCommand = new SqlCommand("select* from Position", cnn);

            dataPosition.Fill(ds, "Position");
            
            bindingSource2.DataSource = ds.Tables["Position"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = "select count(EmployerId) from Employer where Mail = @Mail and Password = @Password";
            cmd.Parameters.AddWithValue("@Mail", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);

            Console.WriteLine(cmd.ExecuteScalar().ToString());
            //Console.WriteLine(bindingSource1.List[1].ToString());
            if (Convert.ToInt32(cmd.ExecuteScalar()) != 0)
            {
                this.Visible = false;
                /*
                for(int i = 0;  i < ds.Tables["Employer"].Rows.Count; i++)
                {
                    if (bindingSource1.List[4].ToString() == textBox2.Text && bindingSource1.List[5].ToString() == textBox1.Text)
                        break;
                    bindingSource1.Position = i;
                }*/
                //bindingSource1.Position = Convert.ToInt32(cmd.ExecuteScalar());
                /*
                DataTable dt = ds.Tables["Employer"];
                var temp = dt.Columns[1].;
                var temp = dt.Rows.Find(Convert.ToInt32(cmd.ExecuteScalar()))[1];*/

                SqlCommand cm = new SqlCommand();
                cm.Connection = cnn;

                cm.CommandText = "select EmployerId from Employer where Mail = @Mail and Password = @Password";
                cm.Parameters.AddWithValue("@Mail", textBox1.Text);
                cm.Parameters.AddWithValue("@Password", textBox2.Text);

                SqlCommand sql = new SqlCommand();
                sql.Connection = cnn;
                sql.CommandText = "select Position from Employer where EmployerId = @EmployerId";
                sql.Parameters.AddWithValue("@EmployerId", cm.ExecuteScalar());
                var temp = sql.ExecuteScalar();

                if  (temp.ToString() == "Бухгалтер")
                {
                    FormContract formContract = new FormContract();
                    formContract.ShowDialog();
                    formContract.Close();
                }
                else if(temp.ToString() == "Менеджер")
                {
                    FormContract formContract = new FormContract();
                    formContract.ShowDialog();
                    formContract.Close();
                }
                else if(temp.ToString() == "Работник склада")
                {
                    FormMaterial formMaterial = new FormMaterial();
                    formMaterial.ShowDialog();
                    formMaterial.Close();
                }
                else if (temp.ToString() == "Технолог")
                {
                    FormTechnicalCard formTechnicalCard = new FormTechnicalCard();
                    formTechnicalCard.ShowDialog();
                    formTechnicalCard.Close();
                }
                this.Close();
            }
            else
                MessageBox.Show("Неправильно введены почта и пароль");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
