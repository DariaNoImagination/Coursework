using System;
using System.Windows.Forms;

namespace Coursework
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Запуск главного окна приложения (формы Facilities).
            Application.Run(new FacilitiesForm());
        }
    }
}
