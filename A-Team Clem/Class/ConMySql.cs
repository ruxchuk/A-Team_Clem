using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;
using System.Threading;
using System.Globalization;
using System.Data;

namespace A_Team_Clem
{
    class ConMySql
    {
        private MySqlConnection connection;
        public string server, dataBaseName, userName, password, port;
        public int CountAdd = 0;
        public string pathFileDB = @"Files\save\DB.txt";
        public string formatIdNumber = "00000";
        public string formatMonth = "00";
        public ConvertDateTime convertDT;
        
        #region ประกาศค่า add clem
        public int product_type_id = 0;//,
        public int company_id = 0;//,
        public string product_name = "";//,
        public string serial = "";//,
        public string address = "";
        public string phone = "";
        public string status = "";//'รับเคลม, ส่งเคลม, รับของ, สำเร็จ',
        public DateTime date_create;//'วันที่สร้าง',
        public DateTime date_product;//'วันที่หมดอายุ',
        public DateTime date_stamp;//'วันที่แก้ไขล่าสุด',
        public string warranty = "";//ในประกัน, นอกประกัน',
        public double chargebacks = 0;//'เก็บเงินเพิ่ม',
        public string symptom = "";//'อาการเสีย',
        public string equipment = "";//'อุปกรณ์ที่ซ่อม',
        public string detail = "";//'หมายเหตุ',
        public int in_document_number_id = 0;//'ลำดับ id ของเดือนปัจจุบัน',
        public DateTime in_document_number;//'เลขที่เอกสารภายใน',
        public string in_document_number_string = "";//'เลขที่เอกสารภายใน',
        public string out_document_number = "";// 'เลขที่เอกสารภายนอก',
        public string in_serial_clem = "";//'เลขที่ใบรับเคลมภายใน',
        public string out_serial_clem = "";//'เลขที่ใบรับเคลมภายนอก',
        public string clem_type = "";//'ใบรับเคลม, ใบส่งเคลม',
        public string customer_clem = "";//'ลูกค้า-ผู้ส่งเคลม',
        public string employee_receive_clem = "";//'พนักงาน-ผู้รับเคลม',
        public string employee_clem = "";//'พนักงาน-ผู้ส่งเคลม',
        public string company_receive_clem = "";//'บริษัท-ผู้รับเคลม',
        public string company_return = "";//'บริษัท-ผู้คืนของ',
        public string employee_receive_product = "";//'พนักงาน-ผู้รับของ',
        public string employee_return = "";//'พนักงาน-ผู้คืนขอ',
        public string customer_receive_product = "";//'ลูกค้า-ผู้รับของ'

        #endregion

        #region ประกาศค่า customer
        public int customer_id = 0;
        public string name_th = "";
        public string name_en = "";
        //public string address = "";
        //public string phone = "";
        public string email = "";
        public DateTime customer_date_create;
        public DateTime customer_date_stamp;
        #endregion

        #region ประกาศค่า company
        public string company_name_th = "";
        public string company_name_en = "";
        public string company_adddress = "";
        public string company_phone = "";
        public string company_email = "";
        public DateTime company_date_create;
        public DateTime company_date_stamp;
        #endregion

        #region ประกาศค่า employee
        public int employee_id = 0;
        public string employee_name_th = "";
        public string employee_name_en = "";
        public string employee_nickname = "";
        public string employee_ddress = "";
        public string employee_phone = "";
        public DateTime employee_date_start;
        public DateTime employee_date_create;
        public DateTime employee_date_stamp;
        #endregion

        #region ประกาศค่า product
        public int product_id = 0;
        public string product_name_th = "";
        public string product_name_en = "";
        public double product_price = 0;
        public string product_value = "";
        public DateTime product_date_create;
        public DateTime product_date_stamp;
        #endregion

        #region ประกาศค่า product_type
        public string product_type_name_th = "";
        public string product_type_name_en = "";
        public DateTime product_type_date_create;
        public DateTime product_type_date_stamp;
        #endregion

        public ConMySql()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Initialize();

            convertDT = new ConvertDateTime();
        }

        private void Initialize()
        {
            ReadFileConDB readFile = new ReadFileConDB();
            bool resultCheckReadFile = readFile.readFileConDB(pathFileDB);

            if (!resultCheckReadFile)
            {
                MessageBox.Show("ไม่พบไฟล์ที่ใช้เชื่อมต่อฐานข้อมูล");
                FRMSettingConDB settingDB = new FRMSettingConDB(pathFileDB);
                settingDB.ShowDialog();
                return;
            }
            userName = readFile.userName;
            password = readFile.pwd;
            server = readFile.hostName;
            dataBaseName = readFile.dataBaseName;
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                   dataBaseName + ";" + "UID=" + userName + ";" + "PASSWORD=" + password + ";Charset=utf8;";
            connection = new MySqlConnection(connectionString);
            CheckConnect();
            CloseConnection();
            //throw new NotImplementedException();
        }        

        #region Check Connect/Close Connect
        
        public Boolean CheckConnect()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("กรุณาตรวจสอบ Username หรือ Password\nของฐานข้อมูล อีกครั้ง", "แจ้งเตือน"
                   , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
                return false;
            }
            return true;
        }

        public  bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
       
        #endregion

        #region Select

        public void getBillClem(string clemType)
        {
            if (CheckConnect() == true)
            {

                
                MySqlCommand cmd = new MySqlCommand("get_bill_clem", connection); 
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"s_clem_type", clemType);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int countData = 0;
                while (dataReader.Read())
                {
                    countData++;
                }
                CloseConnection();
                dataReader.Close();
            }
        }

        //get รายชื่อลูกค้า
        public List<string>[] getCustomer(int customerID = 0)
        {
            List<string>[] list = new List<string>[9];
            for (int i = 0; i < 9; i++)
            {
                list[i] = new List<string>();
            }

            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_customer", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_customer_id", customerID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["id"] + "");
                        list[1].Add(dataReader["name_th"] + "");
                        list[2].Add(dataReader["name_en"] + "");
                        list[3].Add(dataReader["address"] + "");
                        list[4].Add(dataReader["phone"] + "");
                        list[5].Add(dataReader["email"] + "");
                        list[6].Add(dataReader["date_create"] + "");
                        list[7].Add(dataReader["date_stamp"] + "");
                        list[8].Add(dataReader["email"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    return null;
                }
            }
            CloseConnection();
            return list;
        }

        //get รายการบริษัท
        public List<string>[] getCompany(int companyID = 0)
        {
            List<string>[] list = new List<string>[8];
            for (int i = 0; i < 8; i++)
            {
                list[i] = new List<string>();
            }

            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_company", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_company_id", companyID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["id"] + "");
                        list[1].Add(dataReader["company_name_th"] + "");
                        list[2].Add(dataReader["company_name_en"] + "");
                        list[3].Add(dataReader["address"] + "");
                        list[4].Add(dataReader["phone"] + "");
                        list[5].Add(dataReader["email"] + "");
                        list[6].Add(dataReader["date_create"] + "");
                        list[7].Add(dataReader["date_stamp"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    return null;
                }
            }
            CloseConnection();
            return list;
        }
        
        //get รายการประเภทสินค้า
        public List<string>[] getProductType(int productTypeID = 0)
        {
            List<string>[] list = new List<string>[5];
            for (int i = 0; i < 5; i++)
            {
                list[i] = new List<string>();
            }

            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_product_type", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_product_type_id", productTypeID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["id"] + "");
                        list[1].Add(dataReader["name_th"] + "");
                        list[2].Add(dataReader["name_en"] + "");
                        list[3].Add(dataReader["date_create"] + "");
                        list[4].Add(dataReader["date_stamp"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    return null;
                }
            }
            CloseConnection();
            return list;
        }

        //get รายการสินค้า
        public List<string>[] getProduct(int productID = 0)
        {
            List<string>[] list = new List<string>[7];
            for (int i = 0; i < 7; i++)
            {
                list[i] = new List<string>();
            }

            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_product", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_product_id", productID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["id"] + "");
                        list[1].Add(dataReader["name_th"] + "");
                        list[2].Add(dataReader["name_en"] + "");
                        list[3].Add(dataReader["price"] + "");
                        list[4].Add(dataReader["value"] + "");
                        list[5].Add(dataReader["date_create"] + "");
                        list[6].Add(dataReader["date_stamp"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    return null;
                }
            }
            CloseConnection();
            return list;
        }
        
        //get รายชื่อพนักงาน
        public List<string>[] getEmployee(int employeeID = 0)
        {
            List<string>[] list = new List<string>[9];
            for (int i = 0; i < 9; i++)
            {
                list[i] = new List<string>();
            }

            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_employee", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_employee_id", employeeID);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["id"] + "");
                        list[1].Add(dataReader["name_th"] + "");
                        list[2].Add(dataReader["name_en"] + "");
                        list[3].Add(dataReader["nickname"] + "");
                        list[4].Add(dataReader["address"] + "");
                        list[5].Add(dataReader["phone"] + "");
                        list[6].Add(dataReader["date_start"] + "");
                        list[7].Add(dataReader["date_create"] + "");
                        list[8].Add(dataReader["date_stamp"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    return null;
                }
            }
            CloseConnection();
            return list;
        }

        public int getNewIDClemOfMonth(string clemType)
        {
            int NewID = 1;
            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_new_id_of_month", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@s_clem_type", clemType);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        NewID = int.Parse(dataReader["new_id"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    CloseConnection();
                    return NewID;
                }
            }
            CloseConnection();
            return NewID;
        }

        public string getNewIDDocumentNumber(string clemType)
        {
            int newIDOFMonth = getNewIDClemOfMonth(clem_type);
            string NewID = "00001";
            string yearThaiNow = convertDT.convertToThaiYear(DateTime.Now);
            char[] charYear = yearThaiNow.ToCharArray();
            string newYear = charYear[2].ToString() + charYear[3].ToString();
            string monthNow = DateTime.Now.Month.ToString(formatMonth);
            NewID = newYear + monthNow + newIDOFMonth.ToString(formatIdNumber);
            return NewID;
        }

        public DataSet getListClem(string clemType, int clemID = 0)
        {
            DataSet ds = new DataSet();
            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_list_clem", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_clem_id", clemID);
                    cmd.Parameters.AddWithValue("@s_clem_type", clemType);
                    cmd.Parameters.AddWithValue("@s_customer_name_th", name_th);
                    cmd.Parameters.AddWithValue("@s_phone", phone);
                    cmd.Parameters.AddWithValue("@s_serial", serial);
                    cmd.Parameters.AddWithValue("@s_product_name_th", product_name_th);
                    cmd.Parameters.AddWithValue("@s_in_document_number_string", in_document_number_string);
                    cmd.Parameters.AddWithValue("@s_status", status);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(ds, "get_list_clem");
                    ds.Tables["get_list_clem"].Columns.Add("No.", typeof(string));
                    ds.Tables["get_list_clem"].Columns["No."].SetOrdinal(0);
                }
                catch
                {
                    return null;
                }
            }
            CloseConnection();
            return ds;
        }

        #endregion

        #region Insert

        public bool addClem()
        {
            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("add_clem_product", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_customer_id", customer_id);
                    cmd.Parameters.AddWithValue("@i_product_type_id", product_type_id);
                    cmd.Parameters.AddWithValue("@i_company_id", company_id);
                    cmd.Parameters.AddWithValue("@s_product_name", product_name);
                    cmd.Parameters.AddWithValue("@s_serial", serial);
                    cmd.Parameters.AddWithValue("@t_address", address);
                    cmd.Parameters.AddWithValue("@s_phone", phone);
                    cmd.Parameters.AddWithValue("@s_status", status);
                    cmd.Parameters.AddWithValue("@dt_date_create", date_create);
                    cmd.Parameters.AddWithValue("@dt_date_product", date_product);
                    cmd.Parameters.AddWithValue("@dt_date_stamp", date_stamp);
                    cmd.Parameters.AddWithValue("@s_warranty", warranty);
                    cmd.Parameters.AddWithValue("@d_chargebacks", chargebacks);
                    cmd.Parameters.AddWithValue("@t_symptom", symptom);
                    cmd.Parameters.AddWithValue("@t_equipment", equipment);
                    cmd.Parameters.AddWithValue("@t_detail", detail);
                    cmd.Parameters.AddWithValue("@i_in_document_number_id", in_document_number_id);
                    cmd.Parameters.AddWithValue("@dt_in_document_number", in_document_number);
                    cmd.Parameters.AddWithValue("@s_out_document_number", out_document_number);
                    cmd.Parameters.AddWithValue("@s_in_serial_clem", in_serial_clem);
                    cmd.Parameters.AddWithValue("@s_out_serial_clem", out_serial_clem);
                    cmd.Parameters.AddWithValue("@s_clem_type", clem_type);
                    cmd.Parameters.AddWithValue("@s_customer_clem", customer_clem);
                    cmd.Parameters.AddWithValue("@s_employee_receive_clem", employee_receive_clem);
                    cmd.Parameters.AddWithValue("@s_employee_clem", employee_clem);
                    cmd.Parameters.AddWithValue("@s_company_receive_clem", company_receive_clem);
                    cmd.Parameters.AddWithValue("@s_company_return", company_return);
                    cmd.Parameters.AddWithValue("@s_employee_receive_product", employee_receive_product);
                    cmd.Parameters.AddWithValue("@s_employee_return", employee_return);
                    cmd.Parameters.AddWithValue("@s_customer_receive_product", customer_receive_product);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            }
            CloseConnection();
            return true;
        }

        public int addCustomer()
        {
            int customerID = 0;
            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("add_customer", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@s_name_th", name_th);
                    cmd.Parameters.AddWithValue("@s_name_en", name_en);
                    cmd.Parameters.AddWithValue("@t_address", address);
                    cmd.Parameters.AddWithValue("@s_phone", phone);
                    cmd.Parameters.AddWithValue("@s_email", email);
                    cmd.Parameters.AddWithValue("@dt_date_create", customer_date_create);
                    cmd.Parameters.AddWithValue("@dt_date_stamp", customer_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        customerID = int.Parse(dataReader["new_id"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    CloseConnection();
                    return customerID;
                }
            }
            else
            {
                return customerID;
            }
            CloseConnection();
            customer_id = customerID;
            return customerID;
        }

        public int addCompany()
        {
            int companyID = 0;
            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("add_company", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@s_company_name_th", company_name_th);
                    cmd.Parameters.AddWithValue("@s_company_name_en", company_name_en);
                    cmd.Parameters.AddWithValue("@t_address", company_adddress);
                    cmd.Parameters.AddWithValue("@s_phone", company_phone);
                    cmd.Parameters.AddWithValue("@s_email", company_email);
                    cmd.Parameters.AddWithValue("@dt_date_create", company_date_create);
                    cmd.Parameters.AddWithValue("@dt_date_stamp", company_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        companyID = int.Parse(dataReader["new_id"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    CloseConnection();
                    return companyID;
                }
            }
            else
            {
                return companyID;
            }
            CloseConnection();
            company_id = companyID;
            return companyID;
        }

        public int addEmployee()
        {
            int employeeID = 0;
            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("add_employee", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@s_name_th", employee_name_th);
                    cmd.Parameters.AddWithValue("@s_name_en", employee_name_en);
                    cmd.Parameters.AddWithValue("@s_nickname", employee_nickname);
                    cmd.Parameters.AddWithValue("@t_address", employee_ddress);
                    cmd.Parameters.AddWithValue("@s_phone", employee_phone);
                    cmd.Parameters.AddWithValue("@dt_date_start", employee_date_start);
                    cmd.Parameters.AddWithValue("@dt_date_create", employee_date_create);
                    cmd.Parameters.AddWithValue("@dt_date_stamp", employee_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        employeeID = int.Parse(dataReader["new_id"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    CloseConnection();
                    return employeeID;
                }
            }
            else
            {
                return employeeID;
            }
            CloseConnection();
            employee_id = employeeID;
            return employeeID;
        }

        public int addProduct()
        {
            int productID = 0;
            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("add_product", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@s_name_th", product_name_th);
                    cmd.Parameters.AddWithValue("@s_name_en", product_name_en);
                    cmd.Parameters.AddWithValue("@d_price", product_price);
                    cmd.Parameters.AddWithValue("@s_value", product_value);
                    cmd.Parameters.AddWithValue("@dt_date_create", product_date_create);
                    cmd.Parameters.AddWithValue("@dt_date_stamp", product_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        productID = int.Parse(dataReader["new_id"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    CloseConnection();
                    return productID;
                }
            }
            else
            {
                return productID;
            }
            CloseConnection();
            product_id = productID;
            return productID;
        }

        public int addProductType()
        {
            int productTypeID = 0;
            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("add_product_type", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@s_name_th", product_type_name_th);
                    cmd.Parameters.AddWithValue("@s_name_en", product_type_name_en);
                    cmd.Parameters.AddWithValue("@dt_date_create", product_type_date_create);
                    cmd.Parameters.AddWithValue("@dt_date_stamp", product_type_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        productTypeID = int.Parse(dataReader["new_id"] + "");
                    }
                    dataReader.Close();
                }
                catch
                {
                    CloseConnection();
                    return productTypeID;
                }
            }
            else
            {
                return productTypeID;
            }
            CloseConnection();
            product_type_id = productTypeID;
            return productTypeID;
        }

        #endregion

        #region Update

        public bool updateClemProduct(int clemID)
        {

            if (CheckConnect())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("update_clem_product", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@i_id", clemID);
                    cmd.Parameters.AddWithValue("@i_customer_id", customer_id);
                    cmd.Parameters.AddWithValue("@i_product_type_id", product_type_id);
                    cmd.Parameters.AddWithValue("@i_company_id", company_id);
                    cmd.Parameters.AddWithValue("@s_product_name", product_name);
                    cmd.Parameters.AddWithValue("@s_serial", serial);
                    cmd.Parameters.AddWithValue("@t_address", address);
                    cmd.Parameters.AddWithValue("@s_phone", phone);
                    cmd.Parameters.AddWithValue("@s_status", status);
                    cmd.Parameters.AddWithValue("@dt_date_create", date_create);
                    cmd.Parameters.AddWithValue("@dt_date_product", date_product);
                    cmd.Parameters.AddWithValue("@dt_date_stamp", date_stamp);
                    cmd.Parameters.AddWithValue("@s_warranty", warranty);
                    cmd.Parameters.AddWithValue("@d_chargebacks", chargebacks);
                    cmd.Parameters.AddWithValue("@t_symptom", symptom);
                    cmd.Parameters.AddWithValue("@t_equipment", equipment);
                    cmd.Parameters.AddWithValue("@t_detail", detail);
                    cmd.Parameters.AddWithValue("@i_in_document_number_id", in_document_number_id);
                    cmd.Parameters.AddWithValue("@dt_in_document_number", in_document_number);
                    cmd.Parameters.AddWithValue("@s_out_document_number", out_document_number);
                    cmd.Parameters.AddWithValue("@s_in_serial_clem", in_serial_clem);
                    cmd.Parameters.AddWithValue("@s_out_serial_clem", out_serial_clem);
                    cmd.Parameters.AddWithValue("@s_clem_type", clem_type);
                    cmd.Parameters.AddWithValue("@s_customer_clem", customer_clem);
                    cmd.Parameters.AddWithValue("@s_employee_receive_clem", employee_receive_clem);
                    cmd.Parameters.AddWithValue("@s_employee_clem", employee_clem);
                    cmd.Parameters.AddWithValue("@s_company_receive_clem", company_receive_clem);
                    cmd.Parameters.AddWithValue("@s_company_return", company_return);
                    cmd.Parameters.AddWithValue("@s_employee_receive_product", employee_receive_product);
                    cmd.Parameters.AddWithValue("@s_employee_return", employee_return);
                    cmd.Parameters.AddWithValue("@s_customer_receive_product", customer_receive_product);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            }
            CloseConnection();
            return true;
        }
        
        #endregion

        #region Delete
        
        public string Delete(string sql)
        {
            if (CheckConnect() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                //try
                //{
                    cmd.ExecuteNonQuery();
                //}
                //catch { }
                CloseConnection();
            }
            return sql;
        }
        
        #endregion
       
    }
}
