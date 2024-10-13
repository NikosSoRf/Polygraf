using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygraf
{
    public partial class FormContract : Form
    {
        public FormContract()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        DataSet ds = new DataSet();
        SqlDataAdapter dataContract = new SqlDataAdapter();
        SqlDataAdapter dataClient = new SqlDataAdapter();
        SqlDataAdapter dataTechnical = new SqlDataAdapter();
        SqlDataAdapter dataHistory = new SqlDataAdapter();

        private void btnFormContract_Click(object sender, EventArgs e)
        {

        }

        private void btnFormTechnicalCard_Click(object sender, EventArgs e)
        {
            FormTechnicalCard form = new FormTechnicalCard();
            form.ShowDialog();
            form.Close();
        }

        private void btnFormMaterials_Click(object sender, EventArgs e)
        {

        }

        private void btnFormEmployer_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string str = ConfigurationManager.ConnectionStrings["Polygraf"].ConnectionString;
            cnn = new SqlConnection(str);
            cnn.Open();

            dataContract.SelectCommand = new SqlCommand("select* from Contract", cnn);

            dataContract.InsertCommand = new SqlCommand("insert into Contract values(@Id, @ClientId, @DateOfBegin, @DateOfEnd)", cnn);
            dataContract.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "ContractId");
            dataContract.InsertCommand.Parameters.Add("@ClientId", SqlDbType.Int, 4, "ClientId");
            dataContract.InsertCommand.Parameters.Add("@DateOfBegin", SqlDbType.Date, 3, "DateOfBegin");
            dataContract.InsertCommand.Parameters.Add("@DateOfEnd", SqlDbType.Date, 3, "DateOfEnd");

            dataContract.UpdateCommand = new SqlCommand("update Contract set ClientId = @ClientId, " +
                "DateOfBegin = @DateOfBegin, DateOfEnd = @DateOfEnd where ContractId = @Id", cnn);
            dataContract.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "ContractId");
            dataContract.UpdateCommand.Parameters.Add("@ClientId", SqlDbType.Int, 4, "ClientId");
            dataContract.UpdateCommand.Parameters.Add("@DateOfBegin", SqlDbType.Date, 3, "DateOfBegin");
            dataContract.UpdateCommand.Parameters.Add("@DateOfEnd", SqlDbType.Date, 3, "DateOfEnd");

            dataContract.DeleteCommand = new SqlCommand("delete from Contract where ContractId = @Id",cnn);
            dataContract.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "ContractId");

            dataContract.Fill(ds, "Contract");

            dataClient.SelectCommand = new SqlCommand("select * from Client", cnn);

            dataClient.InsertCommand = new SqlCommand("insert into Client values(@ClientId, @Name, @Surname)", cnn);
            dataClient.InsertCommand.Parameters.Add("@ClientId", SqlDbType.Int, 4, "ClientId");
            dataClient.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "NameC");
            dataClient.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 50, "SurnameC");

            dataClient.UpdateCommand = new SqlCommand("update Client set NameC = @Name, SurnameC = @Surname where ClientId = @ClientId", cnn);
            dataClient.UpdateCommand.Parameters.Add("@ClientId", SqlDbType.Int, 4, "ClientId");
            dataClient.UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "NameC");
            dataClient.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 50, "SurnameC");

            dataClient.DeleteCommand = new SqlCommand("delete from Client where ClientId = @ClientId", cnn);
            dataClient.DeleteCommand.Parameters.Add("@ClientId", SqlDbType.Int, 4, "ClientId");

            dataClient.Fill(ds, "Client");

            dataTechnical.SelectCommand = new SqlCommand("select * from TechnicalCard",cnn);

            dataTechnical.DeleteCommand = new SqlCommand("delete from TechnicalCard where TCId = @TCId", cnn);
            dataTechnical.DeleteCommand.Parameters.Add("@TCId", SqlDbType.Int, 4, "TCId");

            dataTechnical.Fill(ds, "TechnicalCard");

            dataHistory.SelectCommand = new SqlCommand("select * from HistoryOfContract where ContractId = @ContractId", cnn);
            dataHistory.SelectCommand.Parameters.AddWithValue("@ContractId", 1);
            

            dataHistory.InsertCommand = new SqlCommand("insert into HistoryOfContract values(@ContactId, @DataChange, @Status");
            //dataHistory.InsertCommand.Parameters.Add("@IdHistoryOfContract", SqlDbType.Int, 4, "IdHistoryOfContract");
            dataHistory.InsertCommand.Parameters.Add("@ContactId", SqlDbType.Int, 4, "ContactId");
            dataHistory.InsertCommand.Parameters.Add("@DataChange", SqlDbType.DateTime, 1, "DataChange");
            dataHistory.InsertCommand.Parameters.Add("@Status", SqlDbType.VarChar, 20, "Status");

            dataHistory.Fill(ds, "HistoryOfContract");

            bindingSource1.DataSource = ds.Tables["Contract"];
            bindingSource2.DataSource = ds.Tables["Client"];
            bindingSource3.DataSource = ds.Tables["TechnicalCard"];
            bindingSource4.DataSource = ds.Tables["HistoryOfContract"];


            /*
            textBox1.DataBindings.Add("text", bindingSource1, "ContractId");
            textBox2.DataBindings.Add("text", bindingSource1, "ClientId");
            textBox3.DataBindings.Add("text", bindingSource1, "Id_Status");
            textBox4.DataBindings.Add("text", bindingSource1, "ContractCL");
            dateTimePicker1.DataBindings.Add("Value", bindingSource1, "dateOfBegin");
            dateTimePicker2.DataBindings.Add("Value", bindingSource1, "dateOfEnd");
            */

            textBox5.DataBindings.Add("text", bindingSource2, "NameC");
            textBox6.DataBindings.Add("text", bindingSource2, "SurnameC");
            textBox3.DataBindings.Add("text", bindingSource2, "Phone");

            /*
            DataTable dataTable = new DataTable();
            dataContract.Fill(dataTable);
            bindingSource1.DataSource = dataTable;
            */
            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource4;

            dataGridView1.AutoResizeColumns();
            cnn.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            /*
            FormClient form = new FormClient();
            form.ShowDialog();
            form.Close();*/
            DataRow rowClient = ds.Tables["Client"].NewRow();
            /*for (int i = 0; i < ds.Tables["Client"].Rows.Count; i++)
            {
                //if (ds.Tables["Client"].==1)
            }*/
            //rowClient[0] = Convert.ToInt32(textBox2.Text);
            rowClient[1] = textBox5.Text;
            rowClient[2] = textBox6.Text;
            ds.Tables["Client"].Rows.Add(rowClient);
            if (ds.Tables["Client"].GetChanges(DataRowState.Added) != null)
                dataClient.Update(ds.Tables["Client"]);
            DataRow rowContract = ds.Tables["Contract"].NewRow();
            //rowContract[0] = Convert.ToInt32(textBox1.Text);
            //rowContract[1] = Convert.ToInt32(textBox2.Text);
            rowContract[2] = dateTimePicker1.Value;
            rowContract[3] = dateTimePicker2.Value;
            ds.Tables["Contract"].Rows.Add(rowContract);
            if (ds.Tables["Contract"].GetChanges(DataRowState.Added) != null) 
                dataContract.Update(ds.Tables["Contract"]);
            bindingSource1.MoveFirst();
            bindingSource1.MoveLast();

            textBox5.DataBindings.Add("text", bindingSource2, "Name");
            textBox6.DataBindings.Add("text", bindingSource2, "Surname");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //ds.Tables["TechnicalCard"].Columns.RemoveAt(ds.Tables["Contract"].Rows[bindingSource1.Position][])
            /*DataRow rowContract = (DataRow)bindingSource1.Current;
            bindingSource3.MoveFirst();
            for(int i = 0;i< ds.Tables["TechnicalCard"].Rows.Count; i++)
            {
                DataRow temp = ds.Tables["TechnicalCard"].Rows[i];
                if (temp[1] == rowContract[0])
                    bindingSource3.RemoveCurrent();
                bindingSource3.Position += 1;
            }*/

            try
            {
                bindingSource1.RemoveCurrent();
                if (ds.Tables["Contract"].GetChanges(DataRowState.Deleted) != null)
                    dataContract.Update(ds.Tables["Contract"]);
            }
            catch (System.Data.SqlClient.SqlException exp)
            {
                Console.WriteLine(exp.Message);
                ds.Clear();
                dataContract.Fill(ds, "Contract");
                bindingSource1.DataSource = ds.Tables["Contract"];
                MessageBox.Show("Завершите все технические карты данного контракта!");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            dataContract.Update(ds.Tables["Contract"]);
        }

        private void FormContract_FormClosing(object sender, FormClosingEventArgs e)
        {
            bindingSource1.EndEdit();
            if (ds.Tables["Contract"].GetChanges() != null)
                dataContract.Update(ds.Tables["Contract"]);
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            bindingSource2.Position = bindingSource1.Position;

            dataHistory.SelectCommand = new SqlCommand("select * from HistoryOfContract where ContractId = @ContractId", cnn);
            dataHistory.SelectCommand.Parameters.AddWithValue("@ContractId", bindingSource1.Position);
            //bindingSource4.;
            //ds.Tables["HistoryOfContact"].Clear();
            dataHistory.Fill(ds, "HistoryOfContract");
            bindingSource4.DataSource = ds.Tables["HistoryOfContract"];
            dataGridView2.DataSource = bindingSource4;
            //bindingSource4.Position = bindingSource1.Position;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow rowHistory = ds.Tables["HistoryOfContract"].NewRow();
            /*for (int i = 0; i < ds.Tables["Client"].Rows.Count; i++)
            {
                //if (ds.Tables["Client"].==1)
            }*/
            //rowHistory[0] = Convert.ToInt32(textBox2.Text);
            rowHistory[1] = bindingSource1.Position;
            rowHistory[2] = dateTimePicker3.Value.ToString();
            rowHistory[3] = comboBox1.Text;
            ds.Tables["HistoryOfContract"].Rows.Add(rowHistory);
            if (ds.Tables["HistoryOfContract"].GetChanges(DataRowState.Added) != null)
                dataHistory.Update(ds.Tables["HistoryOfContract"]);
        }
    }
}