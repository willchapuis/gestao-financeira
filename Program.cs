using GestaoFinanceira.Forms;
using GestaoFinanceira.Services;
using System;
using System.Windows.Forms;

namespace GestaoFinanceira
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Inicializa banco e pastas
            BancoService.Inicializar();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Altere para a tela inicial real quando tiver pronta
            Application.Run(new DashboardForm());
        }
    }
}