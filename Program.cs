//Copyright (c) 2025 Héricles França da Silva. Todos os direitos reservados. 

using System;
using System.Windows.Forms;

namespace relatorio_medico
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
