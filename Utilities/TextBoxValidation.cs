using System;
using System.Windows.Forms;

namespace Utilities
{
    public class TextBoxValidation
    {
        public void Letter(KeyPressEventArgs e)
        {
            try
            {
                // VALIDA SI ES UNA LETRA
                if (Char.IsLetter(e.KeyChar))
                {
                    // PERMITE ESCRIBIR
                    e.Handled = false;
                }
                // VALIDA SI USA LA TECLA DE BORRAR 
                else if (Char.IsControl(e.KeyChar))
                {
                    // PERMITE ESCRIBIR
                    e.Handled = false;
                }
                // VALIDA SI USA LA BARRA ESPACIADORA
                else if (Char.IsSeparator(e.KeyChar))
                {
                    // PERMITE ESCRIBIR
                    e.Handled = false;
                }
                else
                {
                    // SI NO ES NINGUNO DE LOS ANTERIORES ENTONCES NO PERMITE ESCRIBIR
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Number(KeyPressEventArgs e)
        {
            try
            {
                // VALIDA SI ES UN NÚMERO
                if (Char.IsNumber(e.KeyChar))
                {
                    // PERMITE ESCRIBIR
                    e.Handled = false;
                }
                // VALIDA SI USA LA TECLA DE BORRAR 
                else if (Char.IsControl(e.KeyChar))
                {
                    // PERMITE ESCRIBIR
                    e.Handled = false;
                }
                // VALIDA SI USA LA BARRA ESPACIADORA
                else if (Char.IsSeparator(e.KeyChar))
                {
                    // PERMITE ESCRIBIR
                    e.Handled = false;
                }
                else
                {
                    // SI NO ES NINGUNO DE LOS ANTERIORES ENTONCES NO PERMITE ESCRIBIR
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
