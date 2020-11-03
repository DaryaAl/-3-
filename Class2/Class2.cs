using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace LibMas
{
    public class Class2
    {//Считать сумму чисел четных столбцов матрицы
        //Параметры:
        //Входные:
        //DataGridView table - таблица
        //Выходные:
        //TextBox textBox1 - форма для вывода ответа
        public static void Summ(DataGridView table, TextBox textBox1)
        {
            TextBox textbox1 = new TextBox();//Создание textbox
            int y, sum;
            for (int i = 1; i < table.ColumnCount; i++)
            {
                sum = 0;//обнуляем сумму
                for(int j = 0; j < table.RowCount; j++)
                {
                    //значение ячейки матрицы
                    y = Convert.ToInt32(table[i, j].Value);
                    //сумма элементов столбца
                    sum = sum + y;
                }
                //вывод ответов на форму
                textBox1.Text = textBox1.Text + " " + sum.ToString();
                i = i + 1;
            }
        }
    }
}
