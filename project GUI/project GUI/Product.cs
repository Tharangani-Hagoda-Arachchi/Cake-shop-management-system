using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace project_GUI
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        String user_name;
        public Product(String un)
        {
            InitializeComponent();
            user_name = un;
        }


        public void BindGrid()
        {
            try
            {
                string connectingstring = "";
                connectingstring = @"server = localhost;Username = root;Password =;database=cake";
                MySqlConnection conn = new MySqlConnection(connectingstring);
                conn.Open();
                string sql = "SELECT * FROM product_detail;";//sql query
                MySqlCommand cmd = new MySqlCommand(sql, conn);//sql command object
                                                               //SqlDataReader reader = cmd.ExecuteReader();
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                ada.Fill(dataTable);//filling the data table
                dataGridViewProduct.DataSource = dataTable;//binding
                                                  //data grid name - dgStudent

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

      

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProid.Text == "")
                {
                    MessageBox.Show("Please Enter Cake Code");
                }

                

                else if (txtmodelname.Text == "")
                {
                    MessageBox.Show("Please Enter Cake Name");
                }
                else if (txtProductcost.Text == "")
                {
                    MessageBox.Show("Please Enter Cost");
                }

                else if (txtquantity.Text == "")
                {
                    MessageBox.Show("Please Enter  Quantity");
                }

                else if (txtcatid.Text == "")
                {
                    MessageBox.Show("Please Enter Category Id");
                }
              


                else
                {


                    string connectingstring = "";
                    connectingstring = @"server = localhost;Username = root;Password =;database=cake";
                    MySqlConnection conn = new MySqlConnection(connectingstring);
                    conn.Open();


                    string sql = @"INSERT INTO product_detail (cake_id,cake_name,total_quantity,size,unit_price,catagory_id)
                 VALUES ('" + txtProid.Text + "','" +txtmodelname.Text + "', '" + Convert.ToDouble(txtquantity.Text) + "','" + txtsize.Text + "','" + Convert.ToDouble( txtProductcost.Text) + "','" +Convert.ToInt32( txtcatid.Text) + "'); ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);//sql command object
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully added");
                    BindGrid();

                    txtProid.Text = "";
                   
                    txtmodelname.Text = "";
                    txtquantity.Text = "";
                    txtsize.Text = "";
                    txtProductcost.Text = "";
                    txtcatid.Text = "";
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProid.Text = "";
            
            txtmodelname.Text = "";
            txtquantity.Text = "";
            txtsize.Text = "";
            txtProductcost.Text = "";
            txtcatid.Text = "";
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void Product_Load(object sender, EventArgs e)
        {

            if (user_name != "admin")
            {
                AddUser.Enabled = false;
                Employee.Enabled = false;
                report.Enabled = false;
            }
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnchoseimage_Click(object sender, EventArgs e)
        {
           /* OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Chose image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog()) == DialogResult.OK)
                    {
                pictureBoxPimage.Image = Image.FromFile(opf.FileName);*/
            }

        private void dashboard_Click(object sender, EventArgs e)
        {

            this.Hide();
            Dashboard frm = new Dashboard(user_name);
            frm.ShowDialog();
        }

        private void order_Click(object sender, EventArgs e)
        {

            this.Hide();
            Order frm = new Order(user_name);
            frm.ShowDialog();
        }

        private void orderitem_Click(object sender, EventArgs e)
        {

            this.Hide();
            order_item_detail frm = new order_item_detail(user_name);
            frm.ShowDialog();
        }

        private void payment_Click(object sender, EventArgs e)
        {

            this.Hide();
            order_payment frm = new order_payment(user_name);
            frm.ShowDialog();
        }

        private void category_Click(object sender, EventArgs e)
        {

            this.Hide();
            catagory frm = new catagory(user_name);
            frm.ShowDialog();
        }

       

       

       

        private void coustomer_Click(object sender, EventArgs e)
        {

            this.Hide();
            Customer frm = new Customer(user_name);
            frm.ShowDialog();
        }

       

        private void logout_Click(object sender, EventArgs e)
        {

            this.Hide();
            Log_out frm = new Log_out(user_name);
            frm.ShowDialog();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProid.Text == "")
                {
                    MessageBox.Show("Please Enter Cake Code");
                }

                
                

                else if (txtmodelname.Text == "")
                {
                    MessageBox.Show("Please Enter Cake Name");
                }
                else if (txtProductcost.Text == "")
                {
                    MessageBox.Show("Please Enter Cost");
                }

                else if (txtquantity.Text == "")
                {
                    MessageBox.Show("Please Enter  Quantity");
                }

                else if (txtcatid.Text == "")
                {
                    MessageBox.Show("Please Enter Category Id");
                }
                


                else
                {

                    string connectingstring = "";
                    connectingstring = @"server = localhost;Username = root;Password =;database=cake";
                    MySqlConnection conn = new MySqlConnection(connectingstring);
                    conn.Open();


                    string sql = @"UPDATE  product_detail SET cake_name= '" + txtmodelname.Text + "',total_quantity= '" + (Convert.ToDouble(txtquantity.Text) + "',size='" +txtsize.Text + "',unit_price='" + Convert.ToDouble(txtProductcost.Text) + "',catagory_id= '" + Convert.ToInt32(txtcatid.Text) + "' WHERE cake_id='" + txtProid.Text + "';");


                    MySqlCommand cmd = new MySqlCommand(sql, conn);//sql command object
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Successfully Update");
                    BindGrid();


                    txtProid.Text = "";
                   
                    txtmodelname.Text = "";
                    txtquantity.Text = "";
                    txtsize.Text = "";
                    txtProductcost.Text = "";
                    txtcatid.Text = "";
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try {
                if (txtProid.Text == "")
                {
                    MessageBox.Show("Please Enter Cake Code Want to delete");
                }
                else
                {
                    if (MessageBox.Show("Are you want to Delete?", "Delete record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        string connectingstring = "";
                        connectingstring = @"server = localhost;Username = root;Password =;database=cake";
                        MySqlConnection conn = new MySqlConnection(connectingstring);
                        conn.Open();


                        string sql = " DELETE FROM `product_detail` WHERE cake_id='" + txtProid.Text + "';";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);//sql command object
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Deleted");
                        conn.Close();
                        BindGrid();
                        txtProid.Text = "";
                    }
                }
            } catch(Exception ex){
                throw ex;
            }
        }

       

        private void Employee_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empoyee frm = new Empoyee(user_name);
            frm.ShowDialog();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_user frm = new Add_user(user_name);
            frm.ShowDialog();
        }

        private void report_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report frm = new Report(user_name);
            frm.ShowDialog();
        }
    }
    }

