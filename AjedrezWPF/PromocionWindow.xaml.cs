using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AjedrezWPF {
    /// <summary>
    /// Lógica de interacción para PromocionWindow.xaml
    /// </summary>
    public partial class PromocionWindow : Window {
        public PromocionWindow() {
            InitializeComponent();
        }
        private void Seleccionar_Click(object sender, RoutedEventArgs e) {
            RadioButton li = (sender as RadioButton);
            this.Tag =  li.Content;
            this.DialogResult = true;
        }

    }
}
