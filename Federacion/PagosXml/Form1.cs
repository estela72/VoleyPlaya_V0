using PagosXml.Dominio;

using System.Collections;
using System.Xml.Schema;
using System.Xml;

namespace PagosXml
{
    public partial class Form1 : Form
    {
        List<Persona>? personas;
        string conceptoPago = "DIETAS";
        string nifFed = "G33627589000";
        string ibanFed = "ES8802160921958700903695";

        public Form1()
        {
            InitializeComponent();
            ibanEmisor.Text = ibanFed;
            nif.Text = nifFed;
            concepto.Text = conceptoPago;
            personas = new List<Persona>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddPerson();
            CleanData();
        }

        private void AddPerson()
        {
            try
            {
                PersonCheck();
                personas.Add(new Persona(this.nombre.Text, this.apellidos.Text, this.dni.Text, this.iban.Text, Convert.ToSingle(this.cantidad.Text)));
                ListViewItem listViewItem = new ListViewItem(new string[] { this.nombre.Text, this.apellidos.Text, this.dni.Text, this.iban.Text, this.cantidad.Text });
                listViewItem.Name = this.dni.Text;
                listView1.Items.Add(listViewItem);
            }
            catch(Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
            } 
        }

        private void CleanData()
        {
            this.nombre.Text = string.Empty;
            this.apellidos.Text = string.Empty;
            this.dni.Text = string.Empty;
            this.iban.Text = string.Empty;
            this.cantidad.Text = string.Empty;
        }

        private void PersonCheck()
        {
            if (string.IsNullOrEmpty(this.nombre.Text))
                throw new ArgumentNullException("Nombre debe contener un valor v�lido");
            if (string.IsNullOrEmpty(this.apellidos.Text))
                throw new ArgumentNullException("Apellidos debe contener un valor v�lido");
            if (string.IsNullOrEmpty(this.dni.Text))
                throw new ArgumentNullException("DNI debe contener un valor v�lido");
            if (string.IsNullOrEmpty(this.iban.Text))
                throw new ArgumentNullException("IBAN debe contener un valor v�lido");
            try
            {
                double val = Convert.ToDouble(this.cantidad.Text);
            }
            catch(Exception)
            {
                throw new ArgumentException("Cantidad debe contener un valor v�lido");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPerson();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CleanData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SaveXmlFile();
                MessageBox.Show("Fichero sepa generado en carpeta MisDocumentos");
            }
            catch(Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
            }

        }

        private void SaveXmlFile()
        { 
            using (var stream = new MemoryStream(File.ReadAllBytes(".\\Infraestructura\\esquema_sepa_file1.xsd")))
            {
                var schema = XmlSchema.Read(XmlReader.Create(stream), null);
                Document doc = new Document();
                doc.CstmrCdtTrfInitn.GrpHdr.NbOfTxs = Convert.ToSByte(personas.Count);
                doc.CstmrCdtTrfInitn.GrpHdr.InitgPty.Nm = "FEDERACION ASTURIANA DE VOLEIBOL";
                doc.CstmrCdtTrfInitn.GrpHdr.InitgPty.Id.OrgId.Othr.Id = nif.Text;
                doc.CstmrCdtTrfInitn.PmtInf.PmtMtd = "TRF";
                doc.CstmrCdtTrfInitn.PmtInf.ReqdExctnDt = DateTime.Now;
                doc.CstmrCdtTrfInitn.PmtInf.Dbtr.Nm = "FEDERACION ASTURIANA DE VOLEIBOL";
                doc.CstmrCdtTrfInitn.PmtInf.Dbtr.Id.OrgId.Othr.Id = nif.Text;
                doc.CstmrCdtTrfInitn.PmtInf.DbtrAcct.Id.IBAN = ibanEmisor.Text;
                doc.CstmrCdtTrfInitn.PmtInf.DbtrAcct.Ccy = "EUR";
                doc.CstmrCdtTrfInitn.PmtInf.DbtrAgt.FinInstnId.BIC = "CMCIESMM";
                doc.CstmrCdtTrfInitn.PmtInf.CdtTrfTxInf = new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[personas.Count];
                short i = 1;
                int indice = 0;
                foreach(Persona persona in personas)
                {
                    var p = new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf();
                    p.PmtId.EndToEndId = i++;
                    p.PmtTpInf.SvcLvl.Cd = "SEPA";
                    p.Amt.InstdAmt.Value = persona.Cantidad1;
                    p.Amt.InstdAmt.Ccy = "EUR";
                    p.Cdtr.Nm = persona.Apellidos1 + ", " + persona.Nombre1;
                    p.Cdtr.Id.PrvtId.Othr.Id = persona.Dni1;
                    p.CdtrAcct.Id.IBAN = persona.Iban1;
                    p.RmtInf.Ustrd = concepto.Text;

                    doc.CstmrCdtTrfInitn.PmtInf.CdtTrfTxInf[indice++] = p;
                }

                System.Xml.Serialization.XmlSerializer writer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Document));

                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//sepa.xml";
                System.IO.FileStream file = System.IO.File.Create(path);

                writer.Serialize(file, doc);
                file.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            personas = new List<Persona>();
            listView1.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
                if (item.Checked)
                {
                    listView1.Items.Remove(item);
                    RemovePersona(item.Name);
                }
        }

        private void RemovePersona(string dni)
        {
            var persona = personas.Where(p => p.Dni1.Equals(dni)).SingleOrDefault();
            if (persona!=null)
               personas.Remove(persona);
        }
    }
}