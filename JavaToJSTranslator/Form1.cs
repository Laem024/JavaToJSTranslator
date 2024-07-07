using System;
using System.Text;
using System.Windows.Forms;

namespace JavaToJSTranslator
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
            cmbTargetLanguage.Items.AddRange(new object[] { "JavaScript", "C++" }); // Agregar opciones al ComboBox
            cmbTargetLanguage.SelectedIndex = 0; // Seleccionar por defecto JavaScript
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            // Obtener el c�digo fuente en Java desde el TextBox
            string javaCode = txtJavaCode.Text;

            // Obtener el lenguaje de destino seleccionado
            string targetLanguage = cmbTargetLanguage.SelectedItem.ToString();

            // Llamar a la funci�n de traducci�n y obtener el c�digo traducido
            string translatedCode = Translate(javaCode, targetLanguage);

            // Mostrar el c�digo traducido en el TextBox correspondiente
            txtTranslatedCode.Text = translatedCode;
        }

        private string Translate(string javaCode, string targetLanguage)
        {
            // Aqu� implementar�as la l�gica real de traducci�n
            if (targetLanguage == "JavaScript")
            {
                return TranslateJavaToJavaScript(javaCode);
            }
            else if (targetLanguage == "C++")
            {
                return TranslateJavaToCpp(javaCode);
            }
            else
            {
                MessageBox.Show("Lenguaje de destino no soportado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }


        private string TranslateJavaToJavaScript(string javaCode)
        {
            // Implementaci�n b�sica de traducci�n de Java a JavaScript
            StringBuilder jsCodeBuilder = new StringBuilder();

            // Dividir el c�digo en l�neas
            string[] lines = javaCode.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            bool isInsideMain = false; // Bandera para controlar si estamos dentro del m�todo main

            foreach (string line in lines)
            {
                // Verificar y traducir cada l�nea seg�n sea necesario
                if (line.Trim().StartsWith("public class"))
                {
                    // Traducci�n de la declaraci�n de clase en Java a comentario en JavaScript
                    jsCodeBuilder.AppendLine("// Clase Java traducida a JavaScript:");
                }
                else if (line.Trim().StartsWith("public static void main"))
                {
                    // Traducci�n de main en Java a funci�n main en JavaScript
                    jsCodeBuilder.AppendLine("function main(args) {");
                    isInsideMain = true;
                }
                else if (line.Trim().Equals("{") && isInsideMain)
                {
                    // Abrir funci�n main en JavaScript
                    jsCodeBuilder.AppendLine("{");
                }
                else if (line.Trim().Equals("}") && isInsideMain)
                {
                    // Cerrar funci�n main en JavaScript
                    jsCodeBuilder.AppendLine("}");
                    isInsideMain = false; // Restablecer la bandera despu�s de cerrar la funci�n main
                }
                else if (!line.Trim().StartsWith("public") && isInsideMain)
                {
                    // Traducci�n de System.out.println a console.log dentro de la funci�n main
                    string translatedLine = line.Replace("System.out.println", "console.log");

                    // Agregar la l�nea traducida al c�digo JavaScript
                    jsCodeBuilder.AppendLine(translatedLine);
                }
            }

            return jsCodeBuilder.ToString();
        }



        private string TranslateJavaToCpp(string javaCode)
        {
            // Implementaci�n b�sica de traducci�n de Java a C++
            StringBuilder cppCodeBuilder = new StringBuilder();

            // Dividir el c�digo en l�neas
            string[] lines = javaCode.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            bool isInsideMain = false; // Bandera para controlar si estamos dentro del m�todo main

            foreach (string line in lines)
            {
                // Verificar y traducir cada l�nea seg�n sea necesario
                if (line.Trim().StartsWith("public class"))
                {
                    // Traducci�n de la declaraci�n de clase en Java a comentario en C++
                    cppCodeBuilder.AppendLine("// Clase Java traducida a C++:");
                }
                else if (line.Trim().StartsWith("public static void main"))
                {
                    // Traducci�n de main en Java a funci�n main en C++
                    cppCodeBuilder.AppendLine("int main(int argc, char* argv[]) {");
                    isInsideMain = true;
                }
                else if (line.Trim().StartsWith("int "))
                {
                    // Traducci�n de declaraci�n de variable entera
                    cppCodeBuilder.AppendLine(line.Replace("int ", "int "));
                }
                else if (line.Trim().StartsWith("if"))
                {
                    // Traducci�n de condicional if
                    string condition = line.Substring(line.IndexOf('('));
                    cppCodeBuilder.AppendLine("if " + condition + " {");
                }
                else if (line.Trim().StartsWith("System.out.println"))
                {
                    // Traducci�n de System.out.println a cout en C++
                    string message = line.Substring(line.IndexOf('"'), line.LastIndexOf('"') - line.IndexOf('"') + 1);
                    cppCodeBuilder.AppendLine("std::cout << " + message + " << std::endl;");
                }
                else if (line.Trim().StartsWith("} else {"))
                {
                    // Traducci�n de else
                    cppCodeBuilder.AppendLine("} else {");
                }
                else if (line.Trim().Equals("}"))
                {
                    // Cerrar funci�n main en C++
                    cppCodeBuilder.AppendLine("}");
                    isInsideMain = false; // Restablecer la bandera despu�s de cerrar la funci�n main
                }
                else
                {
                    // Agregar cualquier otra l�nea tal cual
                    cppCodeBuilder.AppendLine(line);
                }
            }

            return cppCodeBuilder.ToString();
        }
    }
}
