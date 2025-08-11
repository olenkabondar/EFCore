using System;
using System.Linq;
using System.Windows.Forms;

namespace _3Task
{
    /*Завдання 3*
    Використовуючи Visual Studio, створіть проєкт за шаблоном Windows Forms Application. 
    Потрібно: Створити моделі сутностей, використовуючи техніку Database First. 
    (Підключити існуючу базу даних з завдання 2 (цього уроку) ) Додати на форму DataGridView і Button
    Реалізувати можливість виведення інформації в DataGridView за натисканням на Button.
     */
    public partial class Form1 : Form
    {
        private MyEFDBEntities _context; // Контекст EF Database

        public Form1()
        {
            InitializeComponent();
            _context = new MyEFDBEntities();
        }

        private void button_LoadData_Click(object sender, EventArgs e)
        {
            //Завантажуємо дані з таблиці Product
            var products = _context.Products.ToList();

            // Виводимо у DataGridView
            dataGridView1.DataSource = products;
        }
    }
}
