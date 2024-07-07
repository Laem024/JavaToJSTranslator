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
            // Obtener el código fuente en Java desde el TextBox
            string javaCode = txtJavaCode.Text;

            // Obtener el lenguaje de destino seleccionado
            string targetLanguage = cmbTargetLanguage.SelectedItem.ToString();

            // Llamar a la función de traducción y obtener el código traducido
            string translatedCode = Translate(javaCode, targetLanguage);

            // Mostrar el código traducido en el TextBox correspondiente
            txtTranslatedCode.Text = translatedCode;
        }

        private string Translate(string javaCode, string targetLanguage)
        {
            // Aquí implementarías la lógica real de traducción
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
            // Implementación básica de traducción de Java a JavaScript
            StringBuilder jsCodeBuilder = new StringBuilder();

            // Dividir el código en líneas
            string[] lines = javaCode.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            bool isInsideMain = false; // Bandera para controlar si estamos dentro del método main

            foreach (string line in lines)
            {
                // Verificar y traducir cada línea según sea necesario
                if (line.Trim().StartsWith("public class"))
                {
                    // Traducción de la declaración de clase en Java a comentario en JavaScript
                    jsCodeBuilder.AppendLine("// Clase Java traducida a JavaScript:");
                }
                else if (line.Trim().StartsWith("public static void main"))
                {
                    // Traducción de main en Java a función main en JavaScript
                    jsCodeBuilder.AppendLine("function main(args) {");
                    isInsideMain = true;
                }
                else if (line.Trim().Equals("{") && isInsideMain)
                {
                    // Abrir función main en JavaScript
                    jsCodeBuilder.AppendLine("{");
                }
                else if (line.Trim().Equals("}") && isInsideMain)
                {
                    // Cerrar función main en JavaScript
                    jsCodeBuilder.AppendLine("}");
                    isInsideMain = false; // Restablecer la bandera después de cerrar la función main
                }
                else if (!line.Trim().StartsWith("public") && isInsideMain)
                {
                    // Traducción de System.out.println a console.log dentro de la función main
                    string translatedLine = line.Replace("System.out.println", "console.log");

                    // Agregar la línea traducida al código JavaScript
                    jsCodeBuilder.AppendLine(translatedLine);
                }
            }

            return jsCodeBuilder.ToString();
        }



        private string TranslateJavaToCpp(string javaCode)
        {
            // Implementación básica de traducción de Java a C++
            StringBuilder cppCodeBuilder = new StringBuilder();

            // Dividir el código en líneas
            string[] lines = javaCode.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            bool isInsideMain = false; // Bandera para controlar si estamos dentro del método main

            foreach (string line in lines)
            {
                // Verificar y traducir cada línea según sea necesario
                if (line.Trim().StartsWith("public class"))
                {
                    // Traducción de la declaración de clase en Java a comentario en C++
                    cppCodeBuilder.AppendLine("// Clase Java traducida a C++:");
                }
                else if (line.Trim().StartsWith("public static void main"))
                {
                    // Traducción de main en Java a función main en C++
                    cppCodeBuilder.AppendLine("int main(int argc, char* argv[]) {");
                    isInsideMain = true;
                }
                else if (line.Trim().StartsWith("int "))
                {
                    // Traducción de declaración de variable entera
                    cppCodeBuilder.AppendLine(line.Replace("int ", "int "));
                }
                else if (line.Trim().StartsWith("if"))
                {
                    // Traducción de condicional if
                    string condition = line.Substring(line.IndexOf('('));
                    cppCodeBuilder.AppendLine("if " + condition + " {");
                }
                else if (line.Trim().StartsWith("System.out.println"))
                {
                    // Traducción de System.out.println a cout en C++
                    string message = line.Substring(line.IndexOf('"'), line.LastIndexOf('"') - line.IndexOf('"') + 1);
                    cppCodeBuilder.AppendLine("std::cout << " + message + " << std::endl;");
                }
                else if (line.Trim().StartsWith("} else {"))
                {
                    // Traducción de else
                    cppCodeBuilder.AppendLine("} else {");
                }
                else if (line.Trim().Equals("}"))
                {
                    // Cerrar función main en C++
                    cppCodeBuilder.AppendLine("}");
                    isInsideMain = false; // Restablecer la bandera después de cerrar la función main
                }
                else
                {
                    // Agregar cualquier otra línea tal cual
                    cppCodeBuilder.AppendLine(line);
                }
            }

            return cppCodeBuilder.ToString();
        }
    }
}
