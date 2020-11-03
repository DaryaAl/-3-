using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Lib_6
{
    public class Class1
    {
        //Очищение массива 
        public static void ClearMas(DataGridView table)
        {
            //Очищаем ячейки таблицы
            for (int i = 0; i < table.ColumnCount; i++)
            {
                for(int j = 0; j < table.RowCount; j++)
                {
                    table[i, j].Value = " ";
                }
            }
                
        }

        //Заполнение массива случайными числами
        //diapazon - диапазон чисел NumericUpDown
        //Выходные параметры:
        //table - таблица DataGridView
        public static void ZpMas(DataGridView table, NumericUpDown diapazon)
        {           
            Random Rand = new Random();//создание Random
            int RandMax = Convert.ToInt32(diapazon.Value);

            //заполняем таблицу случайными значениями
            for (int i = 0; i < table.ColumnCount; i++)
            {
                for (int j = 0; j < table.RowCount; j++)
                {
                    int x = Rand.Next(RandMax);//присваивание х случайного значения
                    table[i, j].Value = x;//заполнение 
                }
            }

        }

        //Сохранение таблицы в файл
        //DataGridView table - таблица
        public static void SaveFile(DataGridView table)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(table.ColumnCount);
                file.WriteLine(table.RowCount);

                for (int i = 0; i < table.ColumnCount; i++)
                    for (int j = 0; j < table.RowCount; j++)
                        file.WriteLine(table[i, j].Value);
                file.Close();
            }
        }

        //Чтение таблицы из файла
        //DataGridView table - таблица
        public static void OpenFile(DataGridView table)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            int columns = 0,
                rows = 0;
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(open.FileName);

                if (Int32.TryParse(file.ReadLine(), out columns))
                {
                    if (Int32.TryParse(file.ReadLine(), out rows))
                    {
                        table.ColumnCount = columns;
                        table.RowCount = rows;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка");
                    return;
                }

                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        table[i, j].Value = file.ReadLine();
                    }
                }
            }
        }
    }
}
