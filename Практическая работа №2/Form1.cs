using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_6;
using LibMas;


namespace Практическая_работа__2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Кнопка Справка
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Практическая работа №3, разработчик Алешина Дарья гр.ИСП-31" +
                "Дана матрица М х N. Для каждого столбца матрицы с четным номером (2, 4,...) найти сумму его элементов." +
                "Условный оператор не использовать");
        }

        //Начальные значения таблицы
        private void Form1_Load(object sender, EventArgs e)
        {
            //table - таблица DataGridView
            table.ColumnCount = 5;//Количество столбцов
            table.RowCount = 1;//Количество строк
        }

        //Кнопка Выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Изменение количества колонок
        private void kolvo_ValueChanged(object sender, EventArgs e)
        {
            table.ColumnCount = Convert.ToInt32(kolvo.Value);
        }

        //Кнопка Заполнить
        private void button1_Click(object sender, EventArgs e)
        {
            Class1.ZpMas(table, diapazon);
        }

        //Кнопка Сохранить
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.SaveFile(table);
        }

        //Кнопка Открыть
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.OpenFile(table);
        }

        //Кнопка Очистить
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.ClearMas(table);
        }

        //Кнопка Расчитать
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();//Очищение textbox
            Class2.Summ(table, textBox1);
        }

        //Изменение количества строк
        private void kolstr_ValueChanged(object sender, EventArgs e)
        {
            table.RowCount = Convert.ToInt32(kolstr.Value);
        }
    }
}
