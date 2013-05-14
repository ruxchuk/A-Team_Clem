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
        public string employee_adress = "";
        public string employee_phone = "";
        public string employee_email = "";
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
            port = readFile.port;
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
                    string sql = @"
                        SELECT
                          `id`,
                          `name_th`,
                          `name_en`,
                          `address`,
                          `phone`,
                          `email`,
                          `date_create`,
                          `date_stamp`,
                          `publish`
                        FROM `customer`
                        WHERE 1
                        AND IF (" + customerID + @"=0, 1, id = " + customerID + @")
                        AND publish = 1
                        ORDER BY id
                        ;
                    ";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("get_customer", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@i_customer_id", customerID);
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
                    string sql = @"
                        SELECT
                          *
                        FROM `company`
                        WHERE 1
                        AND IF (" + companyID + @" = 0, 1, id = " + companyID + @")
                        AND IF ('" + company_name_th + @"'  = '', 1, `company_name_th` LIKE CONCAT('%', '" + company_name_th + @"' , '%'))
                        AND IF ('" + company_phone + @"' = '', 1, phone LIKE CONCAT('%', '" + company_phone + @"', '%'))
                        AND publish = 1
                        ORDER BY id
                        ;
                    ";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("get_company", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@i_company_id", companyID);
                    //cmd.Parameters.AddWithValue("@s_name_th", company_name_th);
                    //cmd.Parameters.AddWithValue("@s_phone", company_phone);
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
                    string sql = @"
                        SELECT
                          *
                        FROM `product_type`
                        WHERE 1
                        AND IF (" + productTypeID + @" = 0, 1, id = " + productTypeID + @")
                        AND publish = 1
                        ORDER BY id
                        ;
                    ";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("get_product_type", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@i_product_type_id", productTypeID);
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
                    string sql = @"
                        SELECT
                          *
                        FROM `product`
                        WHERE 1
                        AND IF (" + productID + @" = 0, 1, id = " + productID + @")
                        AND publish = 1
                        ORDER BY id
                        ;
                    ";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("get_product", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@i_product_id", productID);
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
                    string sql = @"
                        SELECT 
	                        *
                        FROM `employee` 
                        WHERE 1
                        AND IF (" + employeeID + @"  = 0, 1, id = " + employeeID + @" )
                        AND publish = 1
                        ORDER BY id
                        ;
                    ";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("get_employee", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@i_employee_id", employeeID);
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
//                    string sql = @"
//                        DECLARE new_id INT ;
//
//                        SET new_id = 
//                        (
//	                        SELECT
//		                        `in_document_number_id`
//	                        FROM `clem_product`
//	                        WHERE 1
//	                        AND YEAR(`in_document_number`) = YEAR(NOW())
//	                        AND MONTH(`in_document_number`) = MONTH(NOW())
//	                        AND `clem_type` = '" + clemType + @"'
//	                        #AND publish = 1
//	                        ORDER BY `id` DESC
//	                        LIMIT 1
//                        )
//                        ;
//
//                        IF new_id IS NULL 
//                        THEN 
//	                        SET new_id = 1;
//                        ELSE SET new_id = new_id + 1;
//                        END IF ;
//                        SELECT new_id;
//                    ";
                    string sql = @"
                        SELECT
		                    `in_document_number_id` AS new_id
	                    FROM `clem_product`
	                    WHERE 1
	                    AND YEAR(`in_document_number`) = YEAR(NOW())
	                    AND MONTH(`in_document_number`) = MONTH(NOW())
	                    AND `clem_type` = '" + clemType + @"'
	                    #AND publish = 1
	                    ORDER BY `id` DESC
	                    LIMIT 1
                    ";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("get_new_id_of_month", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@s_clem_type", clemType);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        NewID = int.Parse(dataReader["new_id"] + "");
                    }
                    dataReader.Close();
                    if (NewID != 1)
                    {
                        NewID++;
                    }
                    Debug.WriteLine(NewID);
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
            int newIDOFMonth = getNewIDClemOfMonth(clemType);
            string NewID = "00001";
            string startWord = "";
            if (clemType == "ใบรับเคลม/ใบส่งเคลม")
            {
                startWord = "CA";
            }
            else
            {
                startWord = "CB";
            }
            string yearThaiNow = convertDT.convertToThaiYear(DateTime.Now);
            char[] charYear = yearThaiNow.ToCharArray();
            string newYear = charYear[2].ToString() + charYear[3].ToString();
            string monthNow = DateTime.Now.Month.ToString(formatMonth);
            NewID = startWord + newYear + monthNow + "-" + newIDOFMonth.ToString(formatIdNumber);
            return NewID;
        }

        public DataSet getListClem(string clemType, int clemID = 0)
        {
            DataSet ds = new DataSet();
            if (CheckConnect())
            {
                try
                {
                    string sql = @"
                        SELECT 
                          a.`id`,
                          c.`name_th` AS customer_name_th,
                          IF(a.`address`='', '-', a.`address`) AS address,
                          a.`phone`,
	                        IF(a.`serial`='', '-', a.`serial`) AS serial,
                          a.`status`,
                          a.`product_name`,
                          b.`company_name_th`,
                          d.`name_th` AS product_type_name_th,
                          a.`date_product`,
                          a.`chargebacks`,
                          a.`in_document_number_id`,
                          a.`in_document_number_str`,
                          a.`out_document_number`,
                          a.`in_serial_clem`,
                          a.`out_serial_clem`,
                          a.`customer_clem`,
                          a.`employee_receive_clem`,
                          a.`employee_clem`,
                          a.`company_receive_clem`,
                          a.`company_return`,
                          a.`employee_receive_product`,
                          a.`employee_return`,
                          a.`customer_receive_product`,
                          a.`warranty`,
                          a.`symptom`,
                          a.`equipment`,
                          a.`detail`,
	                        a.date_create,
                          a.`date_stamp`
                        FROM
                          `clem_product` a
	                        INNER JOIN `company` b ON (a.`company_id` = b.`id` AND b.publish = 1)
	                        LEFT JOIN `customer` c ON (a.`customer_id` = c.`id` AND c.publish = 1)
	                        INNER JOIN `product_type` d ON (a.`product_type_id` = d.`id` AND d.publish = 1)
                        WHERE 1 
	                        AND a.clem_type = '" + clemType + @"'
	                        AND IF('" + name_th + @"' != "",c.name_th LIKE CONCAT('%','" + name_th + @"','%'), 1)
	                        AND IF('" + phone + @"' != "",c.phone LIKE CONCAT('%','" + phone + @"','%'), 1)
	                        AND IF('" + serial + @"' != "",a.serial LIKE CONCAT('%','" + serial + @"','%'), 1)
	                        AND IF('" + product_name_th + @"' != "",a.product_name LIKE CONCAT('%','" + product_name_th + @"','%'), 1)
	                        AND IF('" + in_document_number_string + @"' != "",a.in_document_number_str LIKE CONCAT('%','" + in_document_number_string + @"','%'), 1)
	                        AND IF('" + status + @"' != "",a.`status` LIKE CONCAT('%','" + status + @"','%'), 1)
	                        AND IF (" + clemID + @" = 0, 1, a.id = " + clemID + @")
                        ORDER BY a.`id` DESC
                        ;
                    ";
                    Debug.WriteLine(sql);
                    //MySqlCommand cmd = new MySqlCommand("get_list_clem", connection);                    
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@i_clem_id", clemID);
                    //cmd.Parameters.AddWithValue("@s_clem_type", clemType);
                    //cmd.Parameters.AddWithValue("@s_customer_name_th", name_th);
                    //cmd.Parameters.AddWithValue("@s_phone", phone);
                    //cmd.Parameters.AddWithValue("@s_serial", serial);
                    //cmd.Parameters.AddWithValue("@s_product_name_th", product_name_th);
                    //cmd.Parameters.AddWithValue("@s_in_document_number_string", in_document_number_string);
                    //cmd.Parameters.AddWithValue("@s_status", status);

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
                    string sql = @"
                        #DECLARE new_id INT ;
                        INSERT INTO clem_product (
	                        customer_id,
	                        product_type_id,
	                        company_id,
	                        product_name,
	                        serial,
	                        address,
	                        phone,
	                        status,
	                        date_create,
	                        date_product,
	                        date_stamp,
	                        warranty,
	                        chargebacks,
	                        symptom,
	                        equipment,
	                        detail,
	                        in_document_number_id,
	                        in_document_number,
	                        in_document_number_str,
	                        out_document_number,
	                        in_serial_clem,
	                        out_serial_clem,
	                        clem_type,
	                        customer_clem,
	                        employee_receive_clem,
	                        employee_clem,
	                        company_receive_clem,
	                        company_return,
	                        employee_receive_product,
	                        employee_return,
	                        customer_receive_product
                        )
                        VALUES (
	                        " + customer_id + @",
	                        " + product_type_id + @", 
	                        " + company_id + @", 
	                        '" + product_name + @"', 
	                        '" + serial + @"',
	                        '" + address + @"' ,
	                        '" + phone + @"', 
	                        '" + status + @"', 
	                        '" + date_create + @"', 
	                        '" + date_product + @"', 
	                        '" + date_stamp + @"', 
	                        '" + warranty + @"', 
	                        '" + chargebacks + @"', 
	                        '" + symptom + @"', 
	                        '" + equipment + @"', 
	                        '" + detail + @"', 
	                        " + in_document_number_id + @" ,
	                        '" + in_document_number + @"',
	                        '" + in_document_number_string + @"',
	                        '" + out_document_number + @"', 
	                        '" + in_serial_clem + @"', 
	                        '" + out_serial_clem + @"', 
	                        '" + clem_type + @"', 
	                        '" + customer_clem + @"', 
	                        '" + employee_receive_clem + @"',
	                        '" + employee_clem + @"', 
	                        '" + company_receive_clem + @"', 
	                        '" + company_return + @"', 
	                        '" + employee_receive_product + @"',
	                        '" + employee_return + @"', 
	                        '" + customer_receive_product + @"'
                        );
                        #SET new_id = LAST_INSERT_ID();
                    ";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("add_clem_product", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@i_customer_id", customer_id);
                    //cmd.Parameters.AddWithValue("@i_product_type_id", product_type_id);
                    //cmd.Parameters.AddWithValue("@i_company_id", company_id);
                    //cmd.Parameters.AddWithValue("@s_product_name", product_name);
                    //cmd.Parameters.AddWithValue("@s_serial", serial);
                    //cmd.Parameters.AddWithValue("@t_address", address);
                    //cmd.Parameters.AddWithValue("@s_phone", phone);
                    //cmd.Parameters.AddWithValue("@s_status", status);
                    //cmd.Parameters.AddWithValue("@dt_date_create", date_create);
                    //cmd.Parameters.AddWithValue("@dt_date_product", date_product);
                    //cmd.Parameters.AddWithValue("@dt_date_stamp", date_stamp);
                    //cmd.Parameters.AddWithValue("@s_warranty", warranty);
                    //cmd.Parameters.AddWithValue("@d_chargebacks", chargebacks);
                    //cmd.Parameters.AddWithValue("@t_symptom", symptom);
                    //cmd.Parameters.AddWithValue("@t_equipment", equipment);
                    //cmd.Parameters.AddWithValue("@t_detail", detail);
                    //cmd.Parameters.AddWithValue("@i_in_document_number_id", in_document_number_id);
                    //cmd.Parameters.AddWithValue("@dt_in_document_number", in_document_number);
                    //cmd.Parameters.AddWithValue("@s_in_document_number_string", in_document_number_string);
                    //cmd.Parameters.AddWithValue("@s_out_document_number", out_document_number);
                    //cmd.Parameters.AddWithValue("@s_in_serial_clem", in_serial_clem);
                    //cmd.Parameters.AddWithValue("@s_out_serial_clem", out_serial_clem);
                    //cmd.Parameters.AddWithValue("@s_clem_type", clem_type);
                    //cmd.Parameters.AddWithValue("@s_customer_clem", customer_clem);
                    //cmd.Parameters.AddWithValue("@s_employee_receive_clem", employee_receive_clem);
                    //cmd.Parameters.AddWithValue("@s_employee_clem", employee_clem);
                    //cmd.Parameters.AddWithValue("@s_company_receive_clem", company_receive_clem);
                    //cmd.Parameters.AddWithValue("@s_company_return", company_return);
                    //cmd.Parameters.AddWithValue("@s_employee_receive_product", employee_receive_product);
                    //cmd.Parameters.AddWithValue("@s_employee_return", employee_return);
                    //cmd.Parameters.AddWithValue("@s_customer_receive_product", customer_receive_product);
                    cmd.ExecuteNonQuery();
                    long newID = cmd.LastInsertedId;
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
                    /*string sql = @"
                        DECLARE new_id INT ;

                        SET new_id = 
                        (SELECT 
                          id
                        FROM
                          `customer` 
                        WHERE 1 
                          AND publish = 1 
                          AND name_th = '" + name_th + @"'
                        ORDER BY id DESC 
                        LIMIT 1 
                        );

                        IF new_id IS NULL 
                        THEN 
                        INSERT INTO `customer` (
                          `name_th`,
                          `name_en`,
                          `address`,
                          `phone`,
                          `email`,
                          `date_create`,
                          `date_stamp`
                        ) 
                        VALUES (
	                        '" + name_th + @"',
	                        '" + name_en + @"',
	                        '" + address + @"',
	                        '" + phone + @"',
	                        '" + email + @"',
	                        '" + date_create + @"',
	                        '" + date_stamp + @"'
                        ) 
                        ;

                        SET new_id = LAST_INSERT_ID();
                        ELSE SET new_id = 0;
                        END IF ;
                        SELECT new_id;
                    ";
                    Debug.WriteLine(sql);*/
                    string sql = @"
                        SELECT 
                          id
                        FROM
                          `customer` 
                        WHERE 1 
                          AND publish = 1 
                          AND name_th = '" + name_th + @"'
                        ORDER BY id DESC 
                        LIMIT 1 
                    ";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("add_customer", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@s_name_th", name_th);
                    //cmd.Parameters.AddWithValue("@s_name_en", name_en);
                    //cmd.Parameters.AddWithValue("@t_address", address);
                    //cmd.Parameters.AddWithValue("@s_phone", phone);
                    //cmd.Parameters.AddWithValue("@s_email", email);
                    //cmd.Parameters.AddWithValue("@dt_date_create", customer_date_create);
                    //cmd.Parameters.AddWithValue("@dt_date_stamp", customer_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        customerID = int.Parse(dataReader["id"] + "");
                    }

                    if (customerID == 0)
                    {
                        sql = @"
                            INSERT INTO `customer` (
                              `name_th`,
                              `name_en`,
                              `address`,
                              `phone`,
                              `email`,
                              `date_create`,
                              `date_stamp`
                            ) 
                            VALUES (
	                            '" + name_th + @"',
	                            '" + name_en + @"',
	                            '" + address + @"',
	                            '" + phone + @"',
	                            '" + email + @"',
	                            '" + date_create + @"',
	                            '" + date_stamp + @"'
                            ) 
                            ;
                        "; 
                        cmd = new MySqlCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        customerID = (int)cmd.LastInsertedId;
                    }
                    else
                    {
                        customerID = 0;
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
                    /*string sql = @"
                        DECLARE new_id INT ;

                        SET new_id = (
	                        SELECT 
		                        id
	                        FROM `company` 
	                        WHERE 1
	                        AND publish = 1
	                        AND company_name_th = '" + company_name_th + @"'
	                        ORDER BY id DESC 
	                        LIMIT 1 
                        )
                        ;

                        IF new_id IS NULL
                        THEN
                        INSERT INTO `company` (
                          `company_name_th`,
                          `company_name_en`,
                          `address`,
                          `phone`,
                          `email`,
                          `date_create`,
                          `date_stamp`
                        )
                        VALUES
                        (
	                        '" + company_name_th + @"',
	                        '" + company_name_en + @"',
	                        '" + company_adddress + @"',
	                        '" + company_phone + @"',
	                        '" + company_email + @"',
	                        '" + company_date_create + @"',
	                        '" + company_date_stamp + @"'
                        )
                        ;
                        SET new_id = LAST_INSERT_ID();
                        ELSE SET new_id = 0;
                        END IF ;
                        SELECT new_id;
                    ";*/
                    string sql = @"
                        SELECT 
		                    id
	                    FROM `company` 
	                    WHERE 1
	                    AND publish = 1
	                    AND company_name_th = '" + company_name_th + @"'
	                    ORDER BY id DESC 
	                    LIMIT 1 
                    ";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("add_company", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@s_company_name_th", company_name_th);
                    //cmd.Parameters.AddWithValue("@s_company_name_en", company_name_en);
                    //cmd.Parameters.AddWithValue("@t_address", company_adddress);
                    //cmd.Parameters.AddWithValue("@s_phone", company_phone);
                    //cmd.Parameters.AddWithValue("@s_email", company_email);
                    //cmd.Parameters.AddWithValue("@dt_date_create", company_date_create);
                    //cmd.Parameters.AddWithValue("@dt_date_stamp", company_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        companyID = int.Parse(dataReader["id"] + "");
                    }
                    if (companyID == 0)
                    {
                        sql = @"
                            INSERT INTO `company` (
                              `company_name_th`,
                              `company_name_en`,
                              `address`,
                              `phone`,
                              `email`,
                              `date_create`,
                              `date_stamp`
                            )
                            VALUES
                            (
	                            '" + company_name_th + @"',
	                            '" + company_name_en + @"',
	                            '" + company_adddress + @"',
	                            '" + company_phone + @"',
	                            '" + company_email + @"',
	                            '" + company_date_create + @"',
	                            '" + company_date_stamp + @"'
                            )
                        ";
                        cmd = new MySqlCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        companyID = (int)cmd.LastInsertedId;
                    }
                    else
                    {
                        companyID = 0;
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
                    /*string sql = @"
                        DECLARE new_id INT ;
                        SET new_id = 
                        (SELECT 
                          id
                        FROM
                          `employee` 
                        WHERE 1 
                          AND publish = 1 
                          AND name_th = '" + employee_name_th + @"'
                        ORDER BY id DESC 
                        LIMIT 1 
                        );

                        IF new_id IS NULL 
                        THEN 
                        INSERT INTO `employee` (
                          `name_th`,
	                        `name_en`,
	                        `nickname`,
	                        `address`,
	                        `phone`,
	                        `email`,
	                        `date_start`,
	                        `date_create`,
	                        `date_stamp`
                        ) 
                        VALUES
                        (
	                        '" + employee_name_th + @"',
	                        '" + employee_name_en + @"',
	                        '" + employee_nickname + @"',
	                        '" + employee_adress + @"',
	                        '" + employee_phone + @"',
	                        '" + employee_email + @"',
	                        '" + employee_date_start + @"',
	                        '" + employee_date_create + @"',
	                        '" + employee_date_stamp + @"'
                        ) 
                        ;

                        SET new_id = LAST_INSERT_ID();
                        ELSE SET new_id = 0;
                        END IF ;
                        SELECT new_id;
                        ";
                    */
                    string sql = @"
                        SELECT 
                          id
                        FROM
                          `employee` 
                        WHERE 1 
                          AND publish = 1 
                          AND name_th = '" + employee_name_th + @"'
                        ORDER BY id DESC 
                        LIMIT 1
                    ";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("add_employee", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@s_name_th", employee_name_th);
                    //cmd.Parameters.AddWithValue("@s_name_en", employee_name_en);
                    //cmd.Parameters.AddWithValue("@s_nickname", employee_nickname);
                    //cmd.Parameters.AddWithValue("@t_address", employee_ddress);
                    //cmd.Parameters.AddWithValue("@s_phone", employee_phone);
                    //cmd.Parameters.AddWithValue("@s_email", employee_email);
                    //cmd.Parameters.AddWithValue("@dt_date_start", employee_date_start);
                    //cmd.Parameters.AddWithValue("@dt_date_create", employee_date_create);
                    //cmd.Parameters.AddWithValue("@dt_date_stamp", employee_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        employeeID = int.Parse(dataReader["id"] + "");
                    }

                    if (employeeID == 0)
                    {
                        sql = @"
                            INSERT INTO `employee` (
                              `name_th`,
	                            `name_en`,
	                            `nickname`,
	                            `address`,
	                            `phone`,
	                            `email`,
	                            `date_start`,
	                            `date_create`,
	                            `date_stamp`
                            ) 
                            VALUES
                            (
	                            '" + employee_name_th + @"',
	                            '" + employee_name_en + @"',
	                            '" + employee_nickname + @"',
	                            '" + employee_adress + @"',
	                            '" + employee_phone + @"',
	                            '" + employee_email + @"',
	                            '" + employee_date_start + @"',
	                            '" + employee_date_create + @"',
	                            '" + employee_date_stamp + @"'
                            ) 
                        ";
                        cmd = new MySqlCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        employeeID = (int)cmd.LastInsertedId;
                    }
                    else
                    {
                        employeeID = 0;
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
                    /*string sql = @"
                        DECLARE new_id INT ;
  
                        SET new_id = 
                        (SELECT 
                          id
                        FROM
                          `product` 
                        WHERE 1 
                          AND publish = 1 
                          AND name_th = '" + product_name_th + @"'
                        ORDER BY id DESC 
                        LIMIT 1 
                        );

                        IF new_id IS NULL 
                        THEN 
                        INSERT INTO `product` (
                          `name_th`,
                          `name_en`,
                          `price`,
                          `value`,
                          `date_create`,
                          `date_stamp`
                        ) 
                        VALUES
                        (
	                        '" + product_name_th + @"',
	                        '" + product_name_en + @"',
	                        '" + product_price + @"',
	                        '" + product_value + @"',
	                        '" + product_type_date_create + @"',
	                        '" + product_type_date_stamp + @"'
                        ) 
                        ;
                        SET new_id = LAST_INSERT_ID();
                        ELSE SET new_id = 0;
                        END IF ;
                        SELECT new_id;
                    ";*/
                    string sql = @"
                        SELECT 
                          id
                        FROM
                          `product` 
                        WHERE 1 
                          AND publish = 1 
                          AND name_th = '" + product_name_th + @"'
                        ORDER BY id DESC 
                        LIMIT 1 ";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("add_product", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@s_name_th", product_name_th);
                    //cmd.Parameters.AddWithValue("@s_name_en", product_name_en);
                    //cmd.Parameters.AddWithValue("@d_price", product_price);
                    //cmd.Parameters.AddWithValue("@s_value", product_value);
                    //cmd.Parameters.AddWithValue("@dt_date_create", product_date_create);
                    //cmd.Parameters.AddWithValue("@dt_date_stamp", product_date_stamp);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        productID = int.Parse(dataReader["id"] + "");
                    }
                    if (productID == 0)
                    {
                        sql = @"
                            INSERT INTO `product` (
                              `name_th`,
                              `name_en`,
                              `price`,
                              `value`,
                              `date_create`,
                              `date_stamp`
                            ) 
                            VALUES
                            (
	                            '" + product_name_th + @"',
	                            '" + product_name_en + @"',
	                            '" + product_price + @"',
	                            '" + product_value + @"',
	                            '" + product_type_date_create + @"',
	                            '" + product_type_date_stamp + @"'
                            )
                        ";
                        cmd = new MySqlCommand(sql, connection);
                        cmd.ExecuteNonQuery();
                        productID = (int)cmd.LastInsertedId;
                    }
                    else
                    {
                        productID = 0;
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
                    string sql = @"
                        DECLARE new_id INT ;

                        SET new_id = 
                        (SELECT 
                          id
                        FROM
                          `product_type` 
                        WHERE 1 
                          AND publish = 1 
                          AND name_th = '" + product_type_name_th + @"'
                        ORDER BY id DESC 
                        LIMIT 1 
                        );

                        IF new_id IS NULL 
                        THEN 
                        INSERT INTO `product_type` (
                          `name_th`,
                          `name_en`,
                          `date_create`,
                          `date_stamp`
                        ) 
                        VALUES
                        (
	                        '" + product_type_name_th + @"',
	                        '" + product_type_name_en + @"',
	                        '" + product_type_date_create + @"',
	                        '" + product_type_date_stamp + @"'
                        ) ;

                        SET new_id = LAST_INSERT_ID();
                        ELSE SET new_id = 0;
                        END IF ;
                        SELECT new_id;
                    ";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    //MySqlCommand cmd = new MySqlCommand("add_product_type", connection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@s_name_th", product_type_name_th);
                    //cmd.Parameters.AddWithValue("@s_name_en", product_type_name_en);
                    //cmd.Parameters.AddWithValue("@dt_date_create", product_type_date_create);
                    //cmd.Parameters.AddWithValue("@dt_date_stamp", product_type_date_stamp);
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
