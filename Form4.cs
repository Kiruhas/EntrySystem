using System;
using System.Windows.Forms;

namespace ProgramForGarazhFinal
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void PeopleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.peopleBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.garazhDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "garazhDataSet.People". При необходимости она может быть перемещена или удалена.
            this.peopleTableAdapter.Fill(this.garazhDataSet.People);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex) // если в листбоксе выбран хотя бы один пункт
            {
                case 0: // если 1 пункт, то поиск по базе по имени
                    peopleBindingSource.Filter = "Name Like '%" + textBox1.Text + "%'";
                    break;
                case 1: // если 2 пункт, то поиск по базе по боксу
                    try {
                        Convert.ToInt32(textBox1.Text); // проверка, что пользователь ввел число
                        label2.Visible = false;
                        peopleBindingSource.Filter = "Box =" + textBox1.Text;
                    } catch // если неправильные данные то показываем сообщение об ошибке
                    {
                        label2.Visible = true;
                    }
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int rowNum = peopleDataGridView.CurrentCell.RowIndex; // выбранная строка
            int cell1 = Convert.ToInt32(peopleDataGridView[1, rowNum].Value); // передаем значение поля "Бокс" выбранной строки
            Form updateData = new Form7(cell1); // передаем параметр "номер бокса"
            updateData.Show();   // открываем форму изменения данных
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex) // активируем кнопку поиска только если выбран один из пунктов листбокса
            {
                case 0:
                    button2.Enabled = true;
                    break;
                case 1:
                    button2.Enabled = true;
                    break;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            peopleTableAdapter.Fill(this.garazhDataSet.People); // заполняем таблицу новыми данными
        }
    }
}
