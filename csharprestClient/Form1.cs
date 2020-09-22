using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharprestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Acciones
        private void button1_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.texto = txtRequestURI.Text;

            string strResponse = string.Empty;

            strResponse = rClient.makeRequest();

            deserialiseJSON(strResponse);
        }
        #endregion

        #region Función para el debug en consola
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion

        private void deserialiseJSON(string strJSON)
        {
            try
            {
                string notices = "globalContent=";
                String[] elements1 = System.Text.RegularExpressions.Regex.Split(strJSON, notices);
                notices = elements1[1];

                string noticesJson = ";Fusion.globalContentConfig=";
                String[] elements2 = System.Text.RegularExpressions.Regex.Split(notices, noticesJson);
                noticesJson = elements2[0];

                var datosResponse = JsonConvert.DeserializeObject<dynamic>(noticesJson);
                
                debugOutput("" + datosResponse.data);

            }
            catch(Exception ex)
            {
                debugOutput("Ocurrió un error: " + ex.Message.ToString());
            }
        }
    }
}
