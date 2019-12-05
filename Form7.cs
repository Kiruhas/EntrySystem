using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramForGarazhFinal
{
    public partial class Form7 : Form
    {
        public Form7(int index)
        {
            InitializeComponent();
            peopleBindingSource.Filter = "Box = " + index; // выводим данные только определенного собственника
        }

        private void PeopleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            peopleBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(garazhDataSet);

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "garazhDataSet.People". При необходимости она может быть перемещена или удалена.
            this.peopleTableAdapter.Fill(garazhDataSet.People);

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Validate(); // проверка на соответствие введенных данных
            peopleBindingSource.EndEdit();
            peopleTableAdapter.Update(garazhDataSet); // сохраняем измененные данные
            Close(); // закрываем форму
        }
    }
}
