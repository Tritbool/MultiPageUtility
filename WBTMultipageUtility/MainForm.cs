using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using WBTMigration.Parsing;
using WBTMigration.Writing;
using XMLToWBT.XmlToAspx;

namespace WBTMultipageUtility
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            this.BackColor = System.Drawing.Color.Black;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            InitializeComponent();
            this.label1.ForeColor = Color.Gainsboro;
            this.label2.ForeColor = Color.Gainsboro;
            label3.ForeColor = Color.Gainsboro;
            label3.Text = string.Empty;
            this.checkBox1.ForeColor = Color.Gainsboro;
            this.checkBox2.ForeColor = Color.Gainsboro;
            this.Name = "WBTMultipageUtility";
            this.Text = "WBTMultipageUtility";
            label1.Text = "Dossier source des fichiers ASPX et/ou XML";
            label2.Text = "Dossier de destination des fichiers générés";
            button1.Text = "Choisir un dossier";
            button2.Text = "Choisir un dossier";
            button3.Text = "Générer !";
            checkBox1.Text = "Générer avec modèle WBT 4";
            checkBox2.Text = "Ecrire les fichiers XML";

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            this.Icon = new Icon("logo_triton.ico");

            pictureBox2.ImageLocation = "about.png";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            new ToolTip().SetToolTip(pictureBox2, "Page de l'auteur");

            pictureBox1.ImageLocation = "logo-Xperteam.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            button1.Click += select_source_click;
            button2.Click += select_dest_click;
            button3.Click += do_it;
            button3.MouseHover += color;
            button3.MouseLeave += uncolor;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void select_source_click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void select_dest_click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://fr.linkedin.com/in/gauthier-lyan-950b79b5");
            Process.Start(sInfo);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void color(object sender, EventArgs e)
        {
            button3.BackColor = Color.HotPink;
            button3.ForeColor = Color.LawnGreen;
        }

        private void uncolor(object sender, EventArgs e)
        {
            button3.BackColor = DefaultBackColor;
            button3.ForeColor = DefaultForeColor;
        }

        private void do_it(object sender, EventArgs e)
        {

            label3.ForeColor = Color.Gainsboro;
            label3.Text = string.Empty;
            this.Refresh();

            //Check that a source folder has been chosen
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Aucun dossier source choisi !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                DialogResult r = DialogResult.Yes;

                //If the destination folder hasn't been chosen, The user is asked if he wants to generate
                // the files in the source folder or not
                if (textBox2.Text == string.Empty)
                {
                    r = MessageBox.Show("Aucun dossier de destination choisi : Voulez-vous générer les fichiers dans le dossier source ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (r == DialogResult.Yes)
                        textBox2.Text = textBox1.Text;
                    this.Refresh();
                }
                // If the user has correctly configured the generation folders, let's start it
                if (r == DialogResult.Yes)
                {

                    //Setting the progress bar
                    progressBar1.Minimum = 0;
                    progressBar1.Step = 1;

                    //WBT3.5 aspx to XML parser
                    ParseWBT35 pt = new ParseWBT35();

                    //XML to WBT4.0.0 parser
                    Parser p = new Parser();
                    //Used to remember which files have failed
                    List<string> ErrorFiles = new List<string>();
                    //Used to read xmls
                    XmlDocument doc = new XmlDocument();
                    //Used to memorize the xml generated from WBT3.5 aspx files and the original aspx file information
                    List<Tuple<XmlDocument, FileInfo>> XMLs = new List<Tuple<XmlDocument, FileInfo>>();

                    //Source directory information
                    DirectoryInfo d = new DirectoryInfo(textBox1.Text);
                    FileInfo f = default(FileInfo);

                    //Setting the progress bar length :
                    // Each aspx file counts twice : XML conversion then ASPX conversion
                    // Each xml fil counts once : ASPX conversion.
                    int fCount = Directory.GetFiles(textBox1.Text, "*.aspx", SearchOption.TopDirectoryOnly).Length * 2;
                    fCount += Directory.GetFiles(textBox1.Text, "*.xml", SearchOption.TopDirectoryOnly).Length;
                    progressBar1.Maximum = fCount;
                    //Used to read the WBT4.0.0 template file
                    string tmplt = string.Empty;
                    if (this.checkBox1.Checked)
                        tmplt = File.ReadAllText("tmplt2.aspx", Encoding.UTF8);


                    button3.BackColor = DefaultBackColor;
                    button3.ForeColor = DefaultForeColor;

                    //Parse every found aspx file.
                    foreach (var file in d.GetFiles("*.aspx"))
                    {
                        try
                        {
                            Writer w = new Writer();
                            label3.Text = "Conversion XML de " + file.Name;
                            this.Refresh();
                            doc = pt.ParseAspx(textBox1.Text + "/" + file.Name);
                            if (doc != null)
                            {
                                XMLs.Add(
                                    new Tuple<XmlDocument, FileInfo>(doc
                                        , file));
                                if (checkBox2.Checked)
                                    w.XmlToFile(doc, textBox2.Text + "/" + file.Name.Replace(".aspx", ".xml"));
                            }
                            else
                            {
                                progressBar1.PerformStep();
                                if (!ErrorFiles.Contains(file.Name))
                                    ErrorFiles.Add(file.Name);
                            }
                        }
                        catch (Exception)
                        {

                            ErrorFiles.Add(file.Name);
                        }
                        finally
                        {
                            progressBar1.PerformStep();
                        }

                    }
                    //Parse every xml file
                    foreach (var file in d.GetFiles("*.xml"))
                    {

                        try
                        {
                            doc.Load(textBox1.Text + "/" + file.Name);
                            p.validate(doc);
                            label3.Text = "Conversion ASPX de " + file.Name;
                            this.Refresh();

                            StreamWriter outputFile = new StreamWriter(textBox2.Text + "/" + file.Name.Replace(".xml", ".aspx"));

                            outputFile.AutoFlush = true;
                            if (this.checkBox1.Checked)
                                outputFile.Write(tmplt.Replace("[[MULTIPAGE]]", p.parseXml(doc)).Replace("[[ASPX_CS_FILE]]", file.Name.Replace(".xml", ".aspx.cs")));
                            else
                                outputFile.Write(p.parseXml(doc));
                            outputFile.Close();


                        }
                        catch (Exception)
                        {

                            ErrorFiles.Add(file.Name);
                        }
                        finally
                        {
                            progressBar1.PerformStep();
                        }
                    }
                    //Parse every converted aspx->xml file
                    foreach (Tuple<XmlDocument, FileInfo> xml in XMLs)
                    {

                        try
                        {
                            p.validate(xml.Item1);
                            label3.Text = "Conversion ASPX de " + xml.Item2.Name.Replace(".aspx", ".xml");
                            this.Refresh();

                            StreamWriter outputFile = new StreamWriter(textBox2.Text + "/" + xml.Item2.Name);
                            outputFile.AutoFlush = true;
                            //If we want to put the generated code into the template
                            if (this.checkBox1.Checked)
                                outputFile.Write(tmplt.Replace("[[MULTIPAGE]]", p.parseXml(xml.Item1)).Replace("[[ASPX_CS_FILE]]", xml.Item2.Name.Replace(".aspx", ".aspx.cs")));
                            else
                                outputFile.Write(p.parseXml(xml.Item1));
                            outputFile.Close();


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            ErrorFiles.Add(xml.Item2.Name.Replace(".aspx", ".xml"));
                        }
                        finally
                        {
                            progressBar1.PerformStep();
                        }
                    }
                    //Label shows a green color when ended
                    label3.ForeColor = Color.LimeGreen;
                    label3.Text = "Terminé !";



                    StringBuilder sb = new StringBuilder();
                    foreach (string s in ErrorFiles)
                    {
                        sb.Append("- " + s + "\n");
                    }
                    //Displaying files which have failed being converted
                    if (sb.Length > 0)
                        MessageBox.Show("Les fichiers :\n\n" + sb.ToString() + "\n\n n'ont pas été traités. (XML ou ASPX non valide)", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //Show the folder containing the result files
                    Process.Start(textBox2.Text);

                    //Reset the generation environment;
                    folderBrowserDialog1.SelectedPath = string.Empty;
                    folderBrowserDialog2.SelectedPath = string.Empty;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    progressBar1.Value = progressBar1.Minimum;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;




                }
            }
        }


    }
}
