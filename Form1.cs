using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using RawInput_dll;

namespace ProgramForGarazhFinal
{
    public partial class Form1 : Form
    {
        public string p;
        private readonly RawInput rawInput;
        string InOut = "test";
        

        public Form1()
        {
            InitializeComponent();
            rawInput = new RawInput(Handle, true); // создаем поток считывания ввода устройств HID
            Method();
        }

        
        public void Method()
        {
            rawInput.KeyPressed += OnKeyPress;  
        }

        private void OnKeyPress(object sender, InputEventArg e)
        {
            p = e.KeyPressEvent.DeviceName.ToString(); // получаем имя устройства ввода
            textBox5.Text = p; // выводим имя устройства (делается только при первой установке программы). Потом удаляем
            if (p == "") InOut = "Выезд"; // тут добавить имена устройств въезда и выезда
            string perev = e.KeyPressEvent.VKeyName; // получаем ключевые имена кнопок для перекодировки в двоичную систему
            switch (perev)
            {
                case "D0":
                    break;
                case "D1":
                    textBox1.Text += "1";
                    break;
                case "D2":
                    textBox1.Text += "2";
                    break;
                case "D3":
                    textBox1.Text += "3";
                    break;
                case "D4":
                    textBox1.Text += "4";
                    break;
                case "D5":
                    textBox1.Text += "5";
                    break;
                case "D6":
                    textBox1.Text += "6";
                    break;
                case "D7":
                    textBox1.Text += "7";
                    break;
                case "D8":
                    textBox1.Text += "8";
                    break;
                case "D9":
                    textBox1.Text += "9";
                    break;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
          
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form viewBase = new Form2();
            viewBase.Show();   // Посмотреть всю базу
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form viewDepts = new Form3();
            viewDepts.Show();   // Посмотреть должников
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form searchInBase = new Form4();
            searchInBase.Show();    // Открыть поиск по базе и изменение
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string connStr = @"Data Source = desktop-cll876e\sqlexpress; Initial Catalog = Garazh; Integrated Security = true";
            SqlConnection connect = new SqlConnection(connStr);
            string IndexDept = "";
            if (textBox1.Text.Length == 12) //Если в строке 12 символов то проверяем по базе, есть ли такой собственник
            {
                decimal res;
                bool isInt = Decimal.TryParse(textBox1.Text, out res); // проверяем ввод на несоответсвие типу

                connect.Open();
                if (res > 0) // если верно то обращаемся к базе
                {
                    SqlCommand com = new SqlCommand("SELECT COUNT(id) FROM People WHERE id=" + textBox1.Text, connect);
                    string count = "0";
                    using (SqlDataReader reader = com.ExecuteReader())
                        while (reader.Read())
                        {
                            count = reader[0].ToString();   // Если находим хотя бы одну строчку с данным ID,
                        }                                   // то начинаем цикл вывода на экран
                    if (Convert.ToInt32(count) != 0)
                    {
                        com = new SqlCommand("SELECT Name FROM people WHERE id=" + textBox1.Text, connect);
                        string fio = "";
                        using (SqlDataReader reader = com.ExecuteReader())
                            while (reader.Read())
                            {
                                fio = (string)reader[0];
                            }
                        textBox2.Text = fio; // выводим ФИО в форму
                        com = new SqlCommand("SELECT Box FROM people WHERE id=" + textBox1.Text, connect);
                        string box = "";
                        using (SqlDataReader reader = com.ExecuteReader())
                            while (reader.Read())
                            {
                                box = reader[0].ToString();
                            }
                        textBox3.Text = box; // выводим номер бокса в форму
                        com = new SqlCommand("SELECT Dept FROM people WHERE id=" + textBox1.Text, connect);
                        string dept = "";
                        using (SqlDataReader reader = com.ExecuteReader())
                            while (reader.Read())
                            {
                                dept = reader[0].ToString();
                            }
                        textBox4.Text = dept; // выводим долг собственника в форму
                        com = new SqlCommand("SELECT IndexDept FROM people WHERE id=" + textBox1.Text, connect); // получаем количество въездов с задолженностью
                        using (SqlDataReader reader = com.ExecuteReader())
                            while (reader.Read())
                            {
                                IndexDept = reader[0].ToString(); // Получаем количество въездов с долгом
                            }
                        if (Convert.ToInt32(dept) > 0) // если есть задолженность
                        {
                            connect.Close();
                            textBox4.BackColor = System.Drawing.Color.Red; // фон красный
                            if (Convert.ToInt32(IndexDept) < 3) // если въездов с долгом <= 3 то разрешаем въезд
                            {
                                int IndexDeptI = Convert.ToInt32(IndexDept) + 1; // переменная для передачи в бд значения въездов
                                
                                using (connect)
                                {
                                    connect.Open();
                                    com = new SqlCommand("UPDATE People SET IndexDept = @IndexDept WHERE id=" + textBox1.Text, connect);
                                    com.Parameters.AddWithValue("@IndexDept", IndexDeptI); // изменили в БД ячейку въездов с долгом
                                    com.ExecuteNonQuery(); 
                                }
                                

                                if (Convert.ToInt32(IndexDept) == 2) // если въездов уже 2, то 
                                {
                                    label5.Text = "Последний въезд до блокировки!";

                                }
                                else if (Convert.ToInt32(IndexDept) == 1) // если въезд 1, то
                                {
                                    label5.Text = "Остался 1 въезд до блокировки!";
                                }
                                else if (Convert.ToInt32(IndexDept) == 0) // если еще въездов не было, то
                                {
                                    label5.Text = "Осталось 2 въезда до блокировки!";
                                }

                            }
                            else
                            {
                                // тут запретить въезд
                                label5.Text = "ВЪЕЗД ЗАПРЕЩЕН ЗА НЕУПЛАТУ ЗАДОЛЖЕННОСТЕЙ!";
                            }
                            label5.Visible = true;
                        }
                        else // иначе если нет задолженности
                        {
                            label5.Visible = false; // убираем показ сообщения запрете въезда
                            textBox4.BackColor = System.Drawing.Color.White; // цвет фона белый
                            connect.Close();
                            using (connect)
                            {
                                connect.Open();
                                int a = 0;
                                com = new SqlCommand("UPDATE People SET IndexDept = @IndexDept WHERE id=" + textBox1.Text, connect);
                                com.Parameters.AddWithValue("@IndexDept", a); // обновляем значение въездов на 0, если человек оплатил долг
                                com.ExecuteNonQuery();
                            } 
                        }
                       if (Convert.ToInt32(IndexDept) < 3) // если въездов с долгом <=3, то фиксируем въезд в журнал
                        {
                            SqlConnection connect1 = new SqlConnection(connStr);
                            
                            using (connect1)
                            {
                                connect1.Open();
                                com = new SqlCommand("INSERT INTO Journal VALUES (@Fio,@Box, @Date, @InOut)", connect1);
                                com.Parameters.AddWithValue("@Fio", fio);
                                com.Parameters.AddWithValue("@Box", box);
                                com.Parameters.AddWithValue("@Date", DateTime.Now);
                                com.Parameters.AddWithValue("@InOut", InOut); // Добавили в журнал запись с ФИО, боксом, временем и идентификатором (Въезд или выезд)
                                com.ExecuteNonQuery();
                            }
                        }
                    } com.Dispose(); // уничтожили команду sql
                }
                
                connect.Close(); // закрыли подключение
                textBox1.Clear(); // очистили поле ввода идентификатора пользователя
            }
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            Form journal = new Form6();
            journal.Show();     // открываем журнал
        }
    }
}